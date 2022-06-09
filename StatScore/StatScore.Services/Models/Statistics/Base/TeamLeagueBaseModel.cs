namespace StatScore.Services.Models.Statistics.Base
{
    public class TeamLeagueBaseModel
    {
        public string TeamName { get; init; }
        public int Wins { get; init; }
        public int Draws { get; init; }
        public int Losses { get; init; }
        public double WinRate => Wins / (double)(Wins + Losses + Draws) * 100;
    }
}
