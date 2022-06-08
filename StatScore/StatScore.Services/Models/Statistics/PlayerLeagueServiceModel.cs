namespace StatScore.Services.Models.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PlayerLeagueServiceModel
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Goals { get; init; }
        public int Assists { get; init; }
        public int Appearences { get; init; }
    }
}
