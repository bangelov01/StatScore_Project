namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models;

    public interface ILeagueService
    {
        public Task<IEnumerable<TeamLeagueStatisticServiceModel>> TopFourTeamsAcrossLeagues();
        public Task<IEnumerable<TeamLeagueStatisticServiceModel>> LeagueTable(int id);
        public Task<LeagueInfoServiceModel> LeagueInfo(int id);
    }
}
