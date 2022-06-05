namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models.Authorization;

    public interface IAuthenticationService
    {
        public Task<ResponseModel> Register(RegisterModel model);
        public Task<TokenModel> Login(LoginModel model);
    }
}
