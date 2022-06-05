namespace StatScore.Services
{
    using Microsoft.EntityFrameworkCore;
    using StatScore.Data;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LeagueService : ILeagueService
    {
        private readonly SSDbContext dbContext;

        public LeagueService(SSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TeamLeagueStatisticServiceModel>> TopFourTeams()
            => await dbContext
                .LeagueStats
                .GroupBy(x => x.Team.Name)
                .Select(g => new TeamLeagueStatisticServiceModel
                {
                    TeamName = g.Key,
                    Wins = g.Sum(s => s.Wins),
                    Draws = g.Sum(s => s.Draws),
                    Losses = g.Sum(s => s.Losses)
                })
                .OrderByDescending(o => o.Wins)
                .ThenByDescending(o => o.Draws)
                .Take(4)
                .ToArrayAsync();
    }
}
