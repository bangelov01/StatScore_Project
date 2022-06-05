namespace StatScore.Services.Models.Authorization
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Username { get; init; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }
    }
}
