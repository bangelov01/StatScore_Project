namespace StatScore.Services.Models.Statistics.Player
{
    using StatScore.Services.Models.Statistics.Base;

    public class PlayerLeagueServiceModel : PlayerLeagueBaseModel
    {
        public string Position { get; init; }
        public bool IsInjured { get; init; }
        public string TeamLogo { get; init; }
    }
}
