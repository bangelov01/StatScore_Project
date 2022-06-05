namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models;

    public interface ILeagueService
    {
        public Task<IEnumerable<TeamLeagueStatisticServiceModel>> TopFourTeams();
    }
}
