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

        public async Task<IEnumerable<TeamLeagueStatisticServiceModel>> TopTeamsAcrossLeagues(int count)
               => await dbContext
                 .LeagueStats
                 .GroupBy(x => x.Team.Name)
                 .Select(g => new TeamLeagueStatisticServiceModel
                 {
                     TeamName = g.Key,
                     Wins = g.Sum(s => s.Wins),
                     Draws = g.Sum(s => s.Draws),
                     Losses = g.Sum(s => s.Losses),
                     Points = g.Sum(s => s.Points),
                 })
                 .OrderByDescending(o => o.Wins)
                 .ThenByDescending(o => o.Draws)
                 .Take(count)
                 .ToArrayAsync();

    }
}
