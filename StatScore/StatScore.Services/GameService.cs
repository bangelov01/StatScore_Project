namespace StatScore.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using StatScore.Data;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models;

    public class GameService : IGameService
    {
        private readonly SSDbContext dbContext;

        public GameService(SSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GameServiceModel>> GamesForLeague(int id)
            => await dbContext
            .Games
            .Where(g => g.LeagueId == id)
            .Select(g => new GameServiceModel
            {
                HomeTeamName = g.HomeTeam.Name,
                AwayTeamName = g.AwayTeam.Name,
                HomeTeamGoals = g.HomeTeamGoals,
                AwayTeamGoals = g.AwayTeamGoals,
                HomeTeamShots = g.HomeTeamShots,
                AwayTeamShots = g.AwayTeamShots,
                HomeTeamFauls = g.HomeTeamFauls,
                AwayTeamFauls = g.AwayTeamFauls,
                HomeTeamPasses = g.HomeTeamPasses,
                AwayTeamPasses = g.AwayTeamPasses,
                Date = g.Date
            })
            .ToArrayAsync();
    }
}
