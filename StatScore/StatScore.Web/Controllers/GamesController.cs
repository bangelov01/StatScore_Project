namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using StatScore.Services.Contracts;

    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public GamesController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet("League/{id}")]
        public async Task<IActionResult> GamesByLeague(int id)
        {
          var games = await statisticsService.GamesForLeague(id);

          return Ok(games);
        }
    }
}
