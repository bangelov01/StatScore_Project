namespace StatScore.Services.Models
{
    public class TeamLeagueStatisticServiceModel
    {
        public string TeamName { get; init; }
        public int Wins { get; init; }
        public int Draws { get; init; }
        public int Losses { get; init; }
        public int Points { get; init; }
        public double WinRate => (double)(Wins + Draws) / (Wins + Losses + Draws) * 100;
    }
}
