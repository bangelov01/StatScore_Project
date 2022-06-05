namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models;

    public interface IPlayerLeagueService
    {
        public Task<IEnumerable<PlayerLeagueStatisticServiceModel>> TopFourPlayersAccrossLeagues();
    }
}
