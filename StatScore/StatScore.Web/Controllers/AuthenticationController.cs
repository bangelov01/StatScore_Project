namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using StatScore.Services.Contracts;
    using StatScore.Services.Models.Authentication;
    using StatScore.Services.Models.Authentication.Import;

    [Route("[controller]")]
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
                return StatusCode(StatusCodes.Status400BadRequest, response);
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
                return StatusCode(StatusCodes.Status404NotFound,
                    new ResponseModel { Status = "Error", Message = "Invalid Username and/or Password!"});
            }

            return Ok(response);
        }
    }
}
