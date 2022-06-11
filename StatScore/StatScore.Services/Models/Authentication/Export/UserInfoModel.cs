namespace StatScore.Services.Models.Authentication.Export
{
    public class UserInfoModel
    {
        public string Id { get; init; }
        public string UserName { get; init; }
        public string Token { get; init; }
        public DateTime Expiration { get; init; }
        public bool IsAdmin { get; init; }
    }
}
