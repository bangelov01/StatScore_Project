namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            this.leagueService = leagueService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeague(int id)
        {
            try
            {
                var league = await leagueService.LeagueInfo(id);

                return Ok(league);
            }
            catch
            {
                return StatusCode(500, "Internal server error!");
            }
        }


        [HttpGet("Stats/{id}")]
        public async Task<IActionResult> GetTable(int id)
        {
            try
            {
                var stats = await leagueService.LeagueStats(id);

                return Ok(stats);
            }
            catch
            {
                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
