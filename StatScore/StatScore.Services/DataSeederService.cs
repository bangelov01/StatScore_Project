namespace StatScore.Services
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using StatScore.Data;

    using StatScore.Data.Models;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models;

    using static StatScore.Services.Models.Authentication.UserRoleModel;

    public class DataSeederService : IDataSeederService
    {
        private readonly SSDbContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppSettingsModel adminDetails;

        public DataSeederService(SSDbContext dbContext,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<AppSettingsModel> adminDetails)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.adminDetails = adminDetails.Value;
        }

        public async Task SeedAdministrator()
        {
            if (await roleManager.RoleExistsAsync(AdminRole) 
                && await roleManager.RoleExistsAsync(UserRole))
            {
                return;
            }

            var adminRole = new IdentityRole { Name = AdminRole };
            var uRole = new IdentityRole { Name = UserRole };

            await roleManager.CreateAsync(adminRole);
            await roleManager.CreateAsync(uRole);

            var admin = new User
            {
                Email = adminDetails.Email,
                UserName = adminDetails.Username
            };

            await userManager.CreateAsync(admin, adminDetails.Password);
            await userManager.AddToRoleAsync(admin, adminRole.Name);
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
                    LogoURL = "https://blog.aphrodite1994.com/wp-content/uploads/2017/09/premier-league-logo-2017.jpg"
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
                    LogoURL = "https://www.nicepng.com/png/detail/58-587263_mciman-city-man-city-fa-cup-logo-png.png"
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

        public async Task SeedLeagueStats()
        {
            if (await dbContext.LeagueStats.AnyAsync())
            {
                return;
            }

            await dbContext.LeagueStats.AddRangeAsync(new[]
            {
                new LeagueStats{
                    LeagueId = 1,
                    TeamId = 1,
                    Wins = 3,
                    Draws = 0,
                    Losses = 1,
                },
                new LeagueStats
                {
                    LeagueId = 1,
                    TeamId = 2,
                    Wins = 1,
                    Draws = 2,
                    Losses = 1,
                },
                new LeagueStats
                {
                    LeagueId = 1,
                    TeamId = 3,
                    Wins = 4,
                    Draws = 0,
                    Losses = 0,
                },
                new LeagueStats
                {
                    LeagueId = 1,
                    TeamId = 4,
                    Wins = 2,
                    Draws = 1,
                    Losses = 1,
                },
                new LeagueStats
                {
                    LeagueId = 3,
                    TeamId = 1,
                    Wins = 1,
                    Draws = 2,
                    Losses = 1,
                },
                new LeagueStats
                {
                    LeagueId = 3,
                    TeamId = 4,
                    Wins = 1,
                    Draws = 1,
                    Losses = 2,
                },
                new LeagueStats
                {
                    LeagueId = 3,
                    TeamId = 3,
                    Wins = 2,
                    Draws = 0,
                    Losses = 2,
                },
                new LeagueStats
                {
                    LeagueId = 3,
                    TeamId = 2,
                    Wins = 4,
                    Draws = 0,
                    Losses = 0,
                },
                new LeagueStats
                {
                    LeagueId = 2,
                    TeamId = 5,
                    Wins = 4,
                    Draws = 0,
                    Losses = 0,
                },
                new LeagueStats
                {
                    LeagueId = 2,
                    TeamId = 6,
                    Wins = 3,
                    Draws = 1,
                    Losses = 0,
                },
                new LeagueStats
                {
                    LeagueId = 2,
                    TeamId = 7,
                    Wins = 1,
                    Draws = 2,
                    Losses = 1,
                },
                new LeagueStats
                {
                    LeagueId = 2,
                    TeamId = 8,
                    Wins = 0,
                    Draws = 3,
                    Losses = 1,
                },
            });

            await dbContext.SaveChangesAsync();
        }

        public async Task SeedGames()
        {
            if (await dbContext.Games.AnyAsync())
            {
                return;
            }

            var games = CreateGames(new int[,] { { 1, 1, 4 }, { 2, 5, 8 }, { 3, 1, 4 } }, new Random());

            await dbContext.Games.AddRangeAsync(games);

            await dbContext.SaveChangesAsync();
        }

        public async Task SeedPlayers()
        {
            if (await dbContext.Players.AnyAsync())
            {
                return;
            }

            await dbContext.Players.AddRangeAsync(new[]
            {
                new Player{FirstName = "Mason", LastName = "Mount", IsInjured = false, Position = "CAM", TeamId = 1},
                new Player{FirstName = "Ngolo", LastName = "Kante", IsInjured = false, Position = "MF", TeamId = 1},
                new Player{FirstName = "Luiz", LastName = "Jorginho", IsInjured = true, Position = "MF", TeamId = 1},
                new Player{FirstName = "Bukayo", LastName = "Saka", IsInjured = false, Position = "FW", TeamId = 2},
                new Player{FirstName = "Alexandre", LastName = "Lacazette", IsInjured = false, Position = "FW", TeamId = 2},
                new Player{FirstName = "Martin", LastName = "Odegard", IsInjured = true, Position = "MF", TeamId = 2},
                new Player{FirstName = "Kevin", LastName = "DeBruyne", IsInjured = false, Position = "MF", TeamId = 3},
                new Player{FirstName = "Phil", LastName = "Foden", IsInjured = false, Position = "MF", TeamId = 3},
                new Player{FirstName = "Jack", LastName = "Grealish", IsInjured = true, Position = "MF", TeamId = 3},
                new Player{FirstName = "Cristiano", LastName = "Ronaldo", IsInjured = false, Position = "FW", TeamId = 4},
                new Player{FirstName = "Jadon", LastName = "Sancho", IsInjured = false, Position = "RW", TeamId = 4},
                new Player{FirstName = "Paul", LastName = "Pogba", IsInjured = false, Position = "CM", TeamId = 4},
                new Player{FirstName = "Karim", LastName = "Benzema", IsInjured = false, Position = "FW", TeamId = 5},
                new Player{FirstName = "Vinicious", LastName = "Junior", IsInjured = false, Position = "LW", TeamId = 5},
                new Player{FirstName = "Toni", LastName = "Kroos", IsInjured = false, Position = "CM", TeamId = 5},
                new Player{FirstName = "Pablo", LastName = "Gavira", IsInjured = false, Position = "CM", TeamId = 6},
                new Player{FirstName = "Ousmane", LastName = "Dembele", IsInjured = false, Position = "RW", TeamId = 6},
                new Player{FirstName = "Gerard", LastName = "Pique", IsInjured = true, Position = "CD", TeamId = 6},
                new Player{FirstName = "Carlos", LastName = "Soler", IsInjured = false, Position = "CM", TeamId = 7},
                new Player{FirstName = "Jose", LastName = "Gaya", IsInjured = false, Position = "CD", TeamId = 7},
                new Player{FirstName = "Goncalo", LastName = "Guedes", IsInjured = false, Position = "FW", TeamId = 7},
                new Player{FirstName = "Marcos", LastName = "Llorente", IsInjured = false, Position = "CM", TeamId = 8},
                new Player{FirstName = "Felipe", LastName = "Monteiro", IsInjured = false, Position = "CD", TeamId = 8},
                new Player{FirstName = "Luis", LastName = "Suarez", IsInjured = false, Position = "FW", TeamId = 8},
            });

            await dbContext.SaveChangesAsync();
        }

        public async Task SeedPlayerLeagueStats()
        {
            if (await dbContext.PlayerLeagueStats.AnyAsync())
            {
                return;
            }

            var plStats = CreatePlayerLeagueStats(new int[,] { { 1, 1, 12 }, { 3, 1, 12 }, { 2, 13, 24 } }, new Random());

            await dbContext.PlayerLeagueStats.AddRangeAsync(plStats);

            await dbContext.SaveChangesAsync();
        }

        private HashSet<Game> CreateGames(int[,] arr, Random rand)
        {
            var result = new HashSet<Game>();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int leagueId = arr[i, 0];
                int firstTeamId = arr[i, 1];
                int lastTeamId = arr[i, 2];

                int save = lastTeamId;

                for (int j = firstTeamId; j <= lastTeamId; j++)
                {
                    result.Add(new Game
                    {
                        LeagueId = leagueId,
                        HomeTeamId = j,
                        AwayTeamId = j == firstTeamId ? lastTeamId : save -= 1,
                        HomeTeamGoals = (byte)rand.Next(0, 10),
                        AwayTeamGoals = (byte)rand.Next(0, 10),
                        HomeTeamFauls = (byte)rand.Next(0, 20),
                        AwayTeamFauls = (byte)rand.Next(0, 20),
                        HomeTeamPasses = rand.Next(100, 680),
                        AwayTeamPasses = rand.Next(100, 680),
                        HomeTeamShots = (byte)rand.Next(0, 15),
                        AwayTeamShots = (byte)rand.Next(0, 15),
                        Date = GetRandomDate(),
                    });
                }
            }

            return result;
        }

        private HashSet<PlayerLeagueStats> CreatePlayerLeagueStats(int[,] arr, Random rand)
        {
            var result = new HashSet<PlayerLeagueStats>();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int leagueId = arr[i, 0];
                int firstPlayerId = arr[i, 1];
                int lastPlayerId = arr[i, 2];

                for (int j = firstPlayerId; j <= lastPlayerId; j++)
                {
                    result.Add(new PlayerLeagueStats
                    {
                        PlayerId = j,
                        LeagueId = leagueId,
                        Goals = (byte)rand.Next(0, 12),
                        Assists = (byte)rand.Next(0, 12),
                        Appearences = (byte)rand.Next(1, 6),
                    });
                }
            }

            return result;
        }

        private DateTime GetRandomDate()
        {
            DateTime start = new DateTime(2022, 1, 1);
            Random gen = new Random();
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
