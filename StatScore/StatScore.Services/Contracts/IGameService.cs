namespace StatScore.Services.Contracts
{
    using StatScore.Services.Models;

    public interface IGameService
    {
        public Task<IEnumerable<GameServiceModel>> GamesForLeague(int id);
    }
}
