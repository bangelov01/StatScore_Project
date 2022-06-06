namespace StatScore.Services.Models.Authentication
{
    public class TokenModel
    {
        public string Token { get; init; }
        public DateTime Expiration { get; init; }
    }
}
