namespace StatScore.Services
{
    using Microsoft.EntityFrameworkCore;
    using StatScore.Data;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models;

    public class TeamLeagueService : ITeamLeagueService
    {
        private readonly SSDbContext dbContext;

        public TeamLeagueService(SSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TeamLeagueStatisticServiceModel>> LeagueTable(int id)
               => await dbContext
               .LeagueStats
               .Where(ls => ls.LeagueId == id)
               .Select(ls => new TeamLeagueStatisticServiceModel
               {
                   TeamName = ls.Team.Name,
                   Wins = ls.Wins,
                   Draws = ls.Draws,
                   Losses = ls.Losses
               })
               .OrderByDescending(o => o.Wins)
               .ThenByDescending(o => o.Draws)
               .ToArrayAsync();

        public async Task<IEnumerable<TeamLeagueStatisticServiceModel>> TopFourTeamsAcrossLeagues()
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
