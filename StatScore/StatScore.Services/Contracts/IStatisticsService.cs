namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models.Game;
    using StatScore.Services.Models.Statistics;
    using StatScore.Services.Models.Statistics.Base;

    public interface IStatisticsService
    {
        public Task<IEnumerable<PlayerLeagueServiceModel>> TopPlayersAccrossLeagues();

        public Task<IEnumerable<TeamLeagueBaseModel>> TopTeamsAcrossLeagues();

        public Task<IEnumerable<TeamLeagueServiceModel>> TeamsForLeague(int id);

        public Task<IEnumerable<GameServiceModel>> GamesForLeague(int id);
    }
}
