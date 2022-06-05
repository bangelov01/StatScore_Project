namespace StatScore.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using StatScore.Data;

    using StatScore.Data.Models;
    using StatScore.Services.Contracts;

    public class DataSeederService : IDataSeederService
    {
        private readonly SSDbContext dbContext;

        public DataSeederService(SSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SeedCountry()
        {
            if (await dbContext.Countries.AnyAsync())
            {
                return;
            }

            await dbContext.Countries.AddRangeAsync(new[]
            {
                new Country {Name = "England"},
                new Country {Name = "Spain"}
            });
        }

        public async Task SeedLeagues()
        {
            if (await dbContext.Leagues.AnyAsync())
            {
                return;
            }

            await dbContext.Leagues.AddRangeAsync(new[]
            {
                new League
                {
                    Name = "Premier League",
                    CountryId = 1,
                    Season = 2022,
                    LogoURL = "https://cdn.freebiesupply.com/images/large/2x/premier-league-logo-png-transparent.png"
                },
                new League
                {
                    Name = "La Liga",
                    CountryId = 2,
                    Season = 2022,
                    LogoURL = "https://www.pngitem.com/pimgs/m/225-2253953_spain-la-liga-logo-hd-png-download.png"
                },
                new League
                {
                    Name = "FA Cup",
                    CountryId = 1,
                    Season = 2022,
                    LogoURL = "https://seeklogo.com/images/E/emirates-fa-cup-logo-4A51E1714E-seeklogo.com.png"
                }
            });

            await dbContext.SaveChangesAsync();
        }

        public async Task SeedTeams()
        {
            if (await dbContext.Teams.AnyAsync())
            {
                return;
            }

            await dbContext.Teams.AddRangeAsync(new[]
            {
                new Team
                {
                    Name = "Chelsea",
                    Trophies = 25,
                    Budget = 200000000,
                    LogoURL = "https://tmssl.akamaized.net/images/wappen/head/631.png?lm=1628160548"
                },
                new Team
                {
                    Name = "Arsenal",
                    Trophies = 31,
                    Budget = 100000000,
                    LogoURL = "https://tmssl.akamaized.net/images/wappen/head/11.png?lm=1489787850"
                },
                new Team
                {
                    Name = "Man. City",
                    Trophies = 23,
                    Budget = 300000000,
                    LogoURL = "https://tmssl.akamaized.net/images/wappen/head/281.png?lm=1467356331"
                },
                new Team
                {
                    Name = "Man. United",
                    Trophies = 32,
                    Budget = 210000000,
                    LogoURL = "https://tmssl.akamaized.net/images/wappen/head/985.png?lm=1457975903"
                },
                new Team
                {
                    Name = "Real Madrid",
                    Trophies = 119,
                    Budget = 350000000,
                    LogoURL = "https://tmssl.akamaized.net/images/wappen/head/418.png?lm=1580722449"
                },
                new Team
                {
                    Name = "Barcelona",
                    Trophies = 92,
                    Budget = 310000000,
                    LogoURL = "https://tmssl.akamaized.net/images/wappen/head/131.png?lm=1406739548"
                },
                new Team
                {
                    Name = "Valencia",
                    Trophies = 45,
                    Budget = 110000000,
                    LogoURL = "https://tmssl.akamaized.net/images/wappen/head/1049.png?lm=1406966320"
                },
                new Team
                {
                    Name = "Atletico Madrid",
                    Trophies = 28,
                    Budget = 150000000,
                    LogoURL = "https://tmssl.akamaized.net/images/wappen/head/13.png?lm=1519120744"
                },
            });

            await dbContext.SaveChangesAsync();
        }

        public Task SeedGames()
        {
            throw new NotImplementedException();
        }

        public Task SeedLeagueStats()
        {
            throw new NotImplementedException();
        }

        public Task SeedPlayerLeagueStats()
        {
            throw new NotImplementedException();
        }

        public Task SeedPlayers()
        {
            throw new NotImplementedException();
        }
    }
}
