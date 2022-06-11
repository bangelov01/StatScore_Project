namespace StatScore.Services
{
    using Microsoft.EntityFrameworkCore;

    using StatScore.Data;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models.Statistics.Base;
    using StatScore.Services.Models.Statistics.Game;
    using StatScore.Services.Models.Statistics.Player;
    using StatScore.Services.Models.Statistics.Team;

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
                HomeTeamGoals = g.HomeGoals,
                AwayTeamGoals = g.AwayGoals,
                HomeTeamShots = g.HomeShots,
                AwayTeamShots = g.AwayShots,
                HomeTeamFauls = g.HomeFauls,
                AwayTeamFauls = g.AwayFauls,
                HomeTeamPasses = g.HomePasses,
                AwayTeamPasses = g.AwayPasses,
                HomeLogoURL = g.HomeTeam.LogoURL,
                AwayLogoURL = g.AwayTeam.LogoURL,
            })
            .Take(5)
            .ToArrayAsync();

        public async Task<IEnumerable<PlayerLeagueServiceModel>> PlayersForLeague(int id)
             => await dbContext
                     .PlayerLeagueStats
                     .Where(pl => pl.LeagueId == id)
                     .Select(pl => new PlayerLeagueServiceModel
                     {
                         FirstName = pl.Player.FirstName,
                         LastName = pl.Player.LastName,
                         IsInjured = pl.Player.IsInjured,
                         Position = pl.Player.Position,
                         Goals = pl.Goals,
                         Assists = pl.Assists,
                         Appearences = pl.Appearences,
                         TeamLogo = pl.Player.Team.LogoURL
                     })
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
                        GoalsAquired = ls.Team.HomeGames.Where(hg => hg.LeagueId == id).Sum(s => s.HomeGoals)
                            + ls.Team.AwayGames.Where(hg => hg.LeagueId == id).Sum(s => s.AwayGoals),
                        GoalsConceded = ls.Team.AwayGames.Where(hg => hg.LeagueId == id).Sum(s => s.HomeGoals)
                            + ls.Team.HomeGames.Where(hg => hg.LeagueId == id).Sum(s => s.AwayGoals),
                    })
                    .OrderByDescending(o => o.Wins)
                    .ThenByDescending(o => o.Draws)
                    .ToArrayAsync();

        public async Task<IEnumerable<PlayerLeagueBaseModel>> TopPlayersAccrossLeagues()
            => await dbContext
               .PlayerLeagueStats
               .GroupBy(g => new { g.Player.FirstName, g.Player.LastName })
               .Select(pl => new PlayerLeagueBaseModel
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
