namespace StatScore.Services.Models.Statistics
{
    using StatScore.Services.Models.Statistics.Base;

    public class TeamLeagueServiceModel : TeamLeagueBaseModel
    {
        public int Points { get; init; }
        public int GoalsAquired { get; init; }
        public int GoalsConceded { get; init; }
    }
}
