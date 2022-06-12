namespace StatScore.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.EntityFrameworkCore;

    using StatScore.Data;
    using StatScore.Data.Models;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models.Statistics.Base;
    using StatScore.Services.Models.Statistics.Game;
    using StatScore.Services.Models.Statistics.Player;
    using StatScore.Services.Models.Statistics.Team;

    public class StatisticsService : IStatisticsService
    {
        private readonly SSDbContext dbContext;
        private readonly IConfigurationProvider mapper;

        public StatisticsService(SSDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper.ConfigurationProvider;

        }

        public async Task<IEnumerable<GameServiceModel>> GamesForLeague(int id)
           => await dbContext
            .Games
            .Where(g => g.LeagueId == id)
            .OrderByDescending(o => o.Date)
            .ProjectTo<GameServiceModel>(mapper)
            .Take(5)
            .ToArrayAsync();

        public async Task<IEnumerable<PlayerLeagueServiceModel>> PlayersForLeague(int id, string sort)
        {
            var playersQuery = dbContext
                    .PlayerLeagueStats
                    .Where(pl => pl.LeagueId == id)
                    .ProjectTo<PlayerLeagueServiceModel>(mapper)
                    .AsQueryable();

            playersQuery = sort switch
            {
                nameof(PlayerLeagueStats.Goals) => playersQuery.OrderByDescending(o => o.Goals),
                nameof(PlayerLeagueStats.Appearences) => playersQuery.OrderByDescending(o => o.Appearences),
                nameof(PlayerLeagueStats.Assists) => playersQuery.OrderByDescending(o => o.Assists),
            };

            return await playersQuery.ToArrayAsync();
        }

        public async Task<IEnumerable<TeamLeagueServiceModel>> TeamsForLeague(int id)
            => await dbContext
                    .LeagueStats
                    .Where(ls => ls.LeagueId == id)
                    .ProjectTo<TeamLeagueServiceModel>(mapper, new {id = id})
                    .OrderByDescending(o => o.Wins)
                    .ThenByDescending(o => o.Draws)
                    .ToArrayAsync();

        public async Task<IEnumerable<PlayerLeagueBaseModel>> TopPlayersAccrossLeagues()
            => await dbContext
               .PlayerLeagueStats
               .GroupBy(g => new GroupModel { FirstName = g.Player.FirstName, LastName = g.Player.LastName })
               .ProjectTo<PlayerLeagueBaseModel>(mapper)
               .OrderByDescending(o => o.Goals)
               .ThenByDescending(o => o.Assists)
               .Take(4)
               .ToArrayAsync();

        public async Task<IEnumerable<TeamLeagueBaseModel>> TopTeamsAcrossLeagues()
        {
            var asd = await dbContext
                 .LeagueStats
                 .GroupBy(x => x.Team.Name)
                 .ProjectTo<TeamLeagueBaseModel>(mapper)
                 .ToArrayAsync();

            return asd.OrderByDescending(o => o.WinRate)
                            .ThenByDescending(o => o.Wins)
                            .Take(4)
                            .ToArray();
        }
    }
}
