namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models.Authentication;
    using StatScore.Services.Models.Authentication.Export;
    using StatScore.Services.Models.Authentication.Import;

    public interface IAuthenticationService
    {
        public Task<ResponseModel> Register(RegisterModel model);
        public Task<UserInfoModel> Login(LoginModel model);
    }
}
