namespace StatScore.Services.Contracts
{
    public interface IDataSeederService
    {
        public Task SeedCountry();
        public Task SeedGames();
        public Task SeedTeams();
        public Task SeedLeagues();
        public Task SeedLeagueStats();
        public Task SeedPlayers();
        public Task SeedPlayerLeagueStats();
    }
}
