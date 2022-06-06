namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models.Authentication;

    public interface IAuthenticationService
    {
        public Task<ResponseModel> Register(RegisterModel model);
        public Task<TokenModel> Login(LoginModel model);
    }
}
