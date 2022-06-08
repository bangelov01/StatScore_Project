namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;

    [Route("[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public TeamsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet("League/{id}")]
        public async Task<IActionResult> TeamsTable(int id)
        {
            try
            {
                var stats = await statisticsService.TeamsForLeague(id);

                return Ok(stats);
            }
            catch
            {
                return StatusCode(500, "Internal server error!");
            }
        }

        [HttpGet("Overall/{count}")]
        public async Task<IActionResult> TopTeamsOverall(int count)
        {
            try
            {
                var teams = await statisticsService.TopTeamsAcrossLeagues(count);

                return Ok(teams);
            }
            catch
            {
                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
