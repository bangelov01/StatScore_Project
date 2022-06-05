namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;
    using StatScore.Web.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILeagueService leagueService;

        public HomeController(ILeagueService leagueService)
        {
            this.leagueService = leagueService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await leagueService.TopFourTeams();

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