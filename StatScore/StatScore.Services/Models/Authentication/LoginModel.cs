namespace StatScore.Services.Models.Authentication
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Username { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }
    }
}
