namespace StatScore.Services.Models.Statistics.Base
{
    public class PlayerLeagueBaseModel
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Goals { get; init; }
        public int Assists { get; init; }
        public int Appearences { get; init; }
    }
}
