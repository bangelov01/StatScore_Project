namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models;

    public interface ITeamLeagueService
    {
        public Task<IEnumerable<TeamLeagueStatisticServiceModel>> TopFourTeamsAcrossLeagues();

        public Task<IEnumerable<TeamLeagueStatisticServiceModel>> LeagueTable(int id);
    }
}
