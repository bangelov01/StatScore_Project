namespace StatScore.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using StatScore.Data;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models;

    public class LeagueService : ILeagueService
    {
        private readonly SSDbContext dbContext;

        public LeagueService(SSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<LeagueInfoServiceModel> LeagueInfo(int id)
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

    }
}
