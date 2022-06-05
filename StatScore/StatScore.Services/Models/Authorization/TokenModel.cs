namespace StatScore.Services.Models.Authorization
{
    public class TokenModel
    {
        public string Token { get; init; }
        public DateTime Expiration { get; init; }
    }
}
