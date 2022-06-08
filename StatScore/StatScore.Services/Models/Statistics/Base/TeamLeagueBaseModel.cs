namespace StatScore.Services.Models.Statistics.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TeamLeagueBaseModel
    {
        public string TeamName { get; init; }
        public int Wins { get; init; }
        public int Draws { get; init; }
        public int Losses { get; init; }
        public double WinRate => (double)(Wins + Draws) / (Wins + Losses + Draws) * 100;
    }
}
