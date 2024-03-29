﻿namespace StatScore.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    using StatScore.Data.Models;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models.Authentication;
    using StatScore.Services.Models.Authentication.Export;
    using StatScore.Services.Models.Authentication.Import;

    using static StatScore.Services.Models.Authentication.UserRoleModel;

    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public AuthenticationService(UserManager<User> userManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<UserInfoModel> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.UtcNow.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new UserInfoModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    IsAdmin = userRoles.Contains(AdminRole)
                };
            }

            return null;
        }

        public async Task<ResponseModel> Register(RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);

            if (userExists != null)
            {
                return new ResponseModel
                {
                    Status = "Error",
                    Message = "User already exists!"
                };
            }

            var user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var resultCreate = await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, UserRole);

            if (!resultCreate.Succeeded)
            {
                return new ResponseModel
                {
                    Status = "Error",
                    Message = "User creation failed! Please check user details and try again."
                };
            }

            return new ResponseModel { Status = "Success", Message = "User created successfully!" };
        }
    }
}
