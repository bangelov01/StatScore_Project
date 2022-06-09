namespace StatScore.Services
{
    using Microsoft.EntityFrameworkCore;
    using StatScore.Data;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models.Game;
    using StatScore.Services.Models.Statistics;
    using StatScore.Services.Models.Statistics.Base;

    public class StatisticsService : IStatisticsService
    {
        private readonly SSDbContext dbContext;

        public StatisticsService(SSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GameServiceModel>> GamesForLeague(int id)
           => await dbContext
            .Games
            .Where(g => g.LeagueId == id)
            .OrderByDescending(o => o.Date)
            .Select(g => new GameServiceModel
            {
                HomeTeamName = g.HomeTeam.Name,
                AwayTeamName = g.AwayTeam.Name,
                HomeTeamGoals = g.HomeTeamGoals,
                AwayTeamGoals = g.AwayTeamGoals,
                HomeTeamShots = g.HomeTeamShots,
                AwayTeamShots = g.AwayTeamShots,
                HomeTeamFauls = g.HomeTeamFauls,
                AwayTeamFauls = g.AwayTeamFauls,
                HomeTeamPasses = g.HomeTeamPasses,
                AwayTeamPasses = g.AwayTeamPasses,
                HomeLogoURL = g.HomeTeam.LogoURL,
                AwayLogoURL = g.AwayTeam.LogoURL,
            })
            .Take(5)
            .ToArrayAsync();

        public async Task<IEnumerable<TeamLeagueServiceModel>> TeamsForLeague(int id)
            => await dbContext
                    .LeagueStats
                    .Where(ls => ls.LeagueId == id)
                    .Select(ls => new TeamLeagueServiceModel
                    {
                        TeamName = ls.Team.Name,
                        Wins = ls.Wins,
                        Draws = ls.Draws,
                        Losses = ls.Losses,
                        logoURL = ls.Team.LogoURL,
                        GoalsAquired = ls.Team.HomeGames.Where(hg => hg.LeagueId == id).Sum(s => s.HomeTeamGoals)
                            + ls.Team.AwayGames.Where(hg => hg.LeagueId == id).Sum(s => s.AwayTeamGoals),
                        GoalsConceded = ls.Team.AwayGames.Where(hg => hg.LeagueId == id).Sum(s => s.HomeTeamGoals)
                            + ls.Team.HomeGames.Where(hg => hg.LeagueId == id).Sum(s => s.AwayTeamGoals),
                    })
                    .OrderByDescending(o => o.Wins)
                    .ThenByDescending(o => o.Draws)
                    .ToArrayAsync();

        public async Task<IEnumerable<PlayerLeagueServiceModel>> TopPlayersAccrossLeagues()
            => await dbContext
               .PlayerLeagueStats
               .GroupBy(g => new { g.Player.FirstName, g.Player.LastName })
               .Select(pl => new PlayerLeagueServiceModel
               {
                   FirstName = pl.Key.FirstName,
                   LastName = pl.Key.LastName,
                   Goals = pl.Sum(s => s.Goals),
                   Assists = pl.Sum(s => s.Assists),
                   Appearences = pl.Sum(s => s.Appearences)

               })
               .OrderByDescending(o => o.Goals)
               .ThenByDescending(o => o.Assists)
               .Take(4)
               .ToArrayAsync();

        public async Task<IEnumerable<TeamLeagueBaseModel>> TopTeamsAcrossLeagues()
            => await dbContext
                 .LeagueStats
                 .GroupBy(x => x.Team.Name)
                 .Select(g => new TeamLeagueBaseModel
                 {
                     TeamName = g.Key,
                     Wins = g.Sum(s => s.Wins),
                     Draws = g.Sum(s => s.Draws),
                     Losses = g.Sum(s => s.Losses),
                 })
                 .OrderByDescending(o => o.Wins)
                 .ThenByDescending(o => o.Draws)
                 .Take(4)
                 .ToArrayAsync();
    }
}
