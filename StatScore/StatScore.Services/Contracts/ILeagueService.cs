namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models;
    public interface ILeagueService
    {
        public Task<LeagueInfoServiceModel> LeagueInfo(int id);

        public Task<IEnumerable<TeamLeagueStatisticServiceModel>> LeagueStats(int id);
    }
}
