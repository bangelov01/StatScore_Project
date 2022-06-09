namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models.Statistics.Base;
    using StatScore.Services.Models.Statistics.Game;
    using StatScore.Services.Models.Statistics.Player;
    using StatScore.Services.Models.Statistics.Team;

    public interface IStatisticsService
    {
        public Task<IEnumerable<PlayerLeagueBaseModel>> TopPlayersAccrossLeagues();

        public Task<IEnumerable<TeamLeagueBaseModel>> TopTeamsAcrossLeagues();

        public Task<IEnumerable<TeamLeagueServiceModel>> TeamsForLeague(int id);

        public Task<IEnumerable<GameServiceModel>> GamesForLeague(int id);

        public Task<IEnumerable<PlayerLeagueServiceModel>> PlayersForLeague(int id);
    }
}
