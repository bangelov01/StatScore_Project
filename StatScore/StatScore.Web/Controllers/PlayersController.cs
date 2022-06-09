namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;

    [Route("[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public PlayersController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet("Overall")]
        public async Task<IActionResult> TopPlayersOverall()
        {
            try
            {
                var players = await statisticsService.TopPlayersAccrossLeagues();

                return Ok(players);
            }
            catch
            {
                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
