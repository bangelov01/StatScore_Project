namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService leagueService;

        public LeaguesController(ILeagueService leagueService)
        {
            this.leagueService = leagueService;
        }

        [HttpGet]
        public async Task<IActionResult> LeaguesBasicInfo()
        {
            try
            {
                var leagues = await leagueService.LeaguesBaseInfo();

                return Ok(leagues);
            }
            catch
            {
                return StatusCode(500, "Internal server error!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> LeagueFullInfo(int id)
        {
            try
            {
                var league = await leagueService.LeagueFullInfo(id);

                return Ok(league);
            }
            catch
            {
                return StatusCode(500, "Internal server error!");
            }
        }


        [HttpGet("Stats/{id}")]
        public async Task<IActionResult> LeagueStats(int id)
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
