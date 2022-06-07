namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models;

    public interface ITeamLeagueService
    {
        public Task<IEnumerable<TeamLeagueStatisticServiceModel>> TopTeamsAcrossLeagues(int count);
    }
}
