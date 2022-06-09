namespace StatScore.Services.Models.Statistics
{
    using StatScore.Services.Models.Statistics.Base;

    public class TeamLeagueServiceModel : TeamLeagueBaseModel
    {
        public string logoURL { get; init; }
        public int Points => (Wins * 3) + (Draws * 1);
        public int GoalsAquired { get; init; }
        public int GoalsConceded { get; init; }
    }
}
