namespace StatScore.Services
{
    using Microsoft.EntityFrameworkCore;

    using StatScore.Data;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models;

    public class PlayerLeagueService : IPlayerLeagueService
    {
        private readonly SSDbContext dbContext;

        public PlayerLeagueService(SSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PlayerLeagueStatisticServiceModel>> TopPlayersAccrossLeagues(int count)
               => await dbContext
               .PlayerLeagueStats
               .GroupBy(g => new { g.Player.FirstName, g.Player.LastName })
               .Select(pl => new PlayerLeagueStatisticServiceModel
               {
                   FirstName = pl.Key.FirstName,
                   LastName = pl.Key.LastName,
                   Goals = pl.Sum(s => s.Goals),
                   Assists = pl.Sum(s => s.Assists),
                   Appearences = pl.Sum(s => s.Appearences)

               })
               .OrderByDescending(o => o.Goals)
               .ThenByDescending(o => o.Assists)
               .Take(count)
               .ToArrayAsync();

    }
}
