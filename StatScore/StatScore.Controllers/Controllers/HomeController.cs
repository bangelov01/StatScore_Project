namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;
    using StatScore.Web.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILeagueService leagueService;
        private readonly IGameService gameService;

        public HomeController(ILeagueService leagueService, IGameService gameService)
        {
            this.leagueService = leagueService;
            this.gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await leagueService.TopFourTeamsAcrossLeagues();

            var result1 = await leagueService.LeagueTable(2);

            var result2 = await leagueService.LeagueInfo(1);

            var result4 = await gameService.GamesForLeague(1);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}