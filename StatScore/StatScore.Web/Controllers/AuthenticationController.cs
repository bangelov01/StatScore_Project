namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using StatScore.Services.Contracts;
    using StatScore.Services.Models.Authentication.Import;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            var response = await authService.Register(model);

            if (response.Status == "Error")
            {
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var response = await authService.Login(model);

            if (response == null)
            {
                return Unauthorized();
            }

            return Ok(response);
        }
    }
}
