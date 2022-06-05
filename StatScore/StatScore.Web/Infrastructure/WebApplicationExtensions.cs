namespace StatScore.Web.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    using StatScore.Data;
    using StatScore.Services;
    using StatScore.Services.Contracts;

    public static class WebApplicationExtensions
    {
        public async static Task<WebApplication> PrepareDatabase(this WebApplication app)
        {
            using var scopedServices = app.Services.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;

            await Migrate(serviceProvider);

            await Seed(serviceProvider);

            return app;
        }

        public static WebApplicationBuilder AddTransient(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IDataSeederService, DataSeederService>();
            builder.Services.AddTransient<ILeagueService, LeagueService>();
            builder.Services.AddTransient<IGameService, GameService>();
            builder.Services.AddTransient<ITeamLeagueService, TeamLeagueService>();
            builder.Services.AddTransient<IPlayerLeagueService, PlayerLeagueService>();

            return builder;
        }

        private async static Task Migrate(IServiceProvider provider)
        {
            var data = provider.GetRequiredService<SSDbContext>();

            await data.Database.MigrateAsync();
        }

        private async static Task Seed(IServiceProvider provider)
        {
            var seeder = provider.GetRequiredService<IDataSeederService>();

            await seeder.SeedCountry();

            await seeder.SeedLeagues();

            await seeder.SeedTeams();

            await seeder.SeedLeagueStats();

            await seeder.SeedGames();

            await seeder.SeedPlayers();

            await seeder.SeedPlayerLeagueStats();
        }
    }
}
