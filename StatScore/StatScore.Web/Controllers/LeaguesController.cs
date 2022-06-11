namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using StatScore.Services.Contracts;

    [Route("[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService leagueService;
        private readonly IStatisticsService statisticsService;

        public LeaguesController(ILeagueService leagueService, IStatisticsService statisticsService)
        {
            this.leagueService = leagueService;
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> LeaguesBasicInfo()
        {

            var leagues = await leagueService.LeaguesBaseInfo();

            return Ok(leagues);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> LeagueFullInfo(int id)
        {
            var league = await leagueService.LeagueFullInfo(id);

            return Ok(league);
        }
    }
}
