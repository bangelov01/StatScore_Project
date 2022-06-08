namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models.League;
    using StatScore.Services.Models.League.Base;

    public interface ILeagueService
    {
        public Task<IEnumerable<LeagueBaseModel>> LeaguesBaseInfo();

        public Task<LeagueInfoServiceModel> LeagueFullInfo(int id);
    }
}
