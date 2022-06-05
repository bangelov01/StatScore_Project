namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamLeagueService teamLeagueService;

        public TeamsController(ITeamLeagueService teamLeagueService)
        {
            this.teamLeagueService = teamLeagueService;
        }

        [HttpGet("Top")]
        public async Task<IActionResult> GetTopFourTeams()
        {
            try
            {
                var teams = await teamLeagueService.TopFourTeamsAcrossLeagues();

                return Ok(teams);
            }
            catch
            {
                //can log exception
                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
