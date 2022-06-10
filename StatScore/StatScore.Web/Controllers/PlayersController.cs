namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models.Statistics.Player;
    using static StatScore.Services.Models.Authentication.UserRoleModel;

    [Authorize(Roles = UserRole)]
    [Route("[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public PlayersController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [AllowAnonymous]
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

        [HttpGet("League")]
        public async Task<IActionResult> PlayersForLeague([FromQuery] SortQuerryModel model)
        {
            try
            {
                var players = await statisticsService.PlayersForLeague(model.Id);

                players = players.OrderByDescending(l => l.GetType().GetProperty(model.Sort).GetValue(l));

                return Ok(players);
            }
            catch

            {
                return StatusCode(500, "Internal server error!");
            }

        }
    }
}
