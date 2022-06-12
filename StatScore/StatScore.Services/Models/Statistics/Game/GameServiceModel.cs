namespace StatScore.Services.Models.Statistics.Game
{
    public class GameServiceModel
    {
        public string HomeTeamName { get; init; }
        public string AwayTeamName { get; init; }
        public byte HomeGoals { get; init; }
        public byte AwayGoals { get; init; }
        public byte HomeShots { get; init; }
        public byte AwayShots { get; init; }
        public int HomePasses { get; init; }
        public int AwayPasses { get; init; }
        public byte HomeFauls { get; init; }
        public byte AwayFauls { get; init; }
        public string HomeLogoURL { get; init; }
        public string AwayLogoURL { get; init; }
    }
}
