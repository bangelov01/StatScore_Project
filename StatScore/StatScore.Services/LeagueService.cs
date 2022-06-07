namespace StatScore.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using StatScore.Data;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models;
    using StatScore.Services.Models.League;
    using StatScore.Services.Models.League.Base;

    public class LeagueService : ILeagueService
    {
        private readonly SSDbContext dbContext;

        public LeagueService(SSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TeamLeagueStatisticServiceModel>> LeagueStats(int id)
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

        public async Task<LeagueInfoServiceModel> LeagueFullInfo(int id)
            => await dbContext
            .Leagues
            .Where(x => x.Id == id)
            .Select(x => new LeagueInfoServiceModel
            {
                Name = x.Name,
                Season = x.Season,
                LogoURL = x.LogoURL,
                CountryName = x.Country.Name
            })
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<LeagueBaseModel>> LeaguesBaseInfo()
            => await dbContext
            .Leagues
            .Select(l => new LeagueBaseModel
            {
                Id = l.Id,
                Name = l.Name
            })
            .ToArrayAsync();
    }
}
