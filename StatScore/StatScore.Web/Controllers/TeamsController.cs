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

        [HttpGet("Top/{count}")]
        public async Task<IActionResult> GetTopTeams(int count)
        {
            try
            {
                var teams = await teamLeagueService.TopTeamsAcrossLeagues(count);

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
