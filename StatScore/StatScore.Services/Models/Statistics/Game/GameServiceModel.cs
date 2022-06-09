namespace StatScore.Services.Models.Statistics.Game
{
    public class GameServiceModel
    {
        public string HomeTeamName { get; init; }
        public string AwayTeamName { get; init; }
        public int HomeTeamGoals { get; init; }
        public int AwayTeamGoals { get; init; }
        public int HomeTeamShots { get; init; }
        public int AwayTeamShots { get; init; }
        public int HomeTeamPasses { get; init; }
        public int AwayTeamPasses { get; init; }
        public int HomeTeamFauls { get; init; }
        public int AwayTeamFauls { get; init; }
        public string HomeLogoURL { get; init; }
        public string AwayLogoURL { get; init; }
    }
}
