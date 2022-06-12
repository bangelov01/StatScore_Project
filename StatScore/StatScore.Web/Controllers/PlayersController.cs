namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using StatScore.Services.Contracts;
    using StatScore.Services.Models.Statistics.Player;

    using static StatScore.Services.Models.Authentication.UserRoleModel;

    [Authorize(Roles = $"{UserRole},{AdminRole}")]
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
           var players = await statisticsService.TopPlayersAccrossLeagues();
          
           return Ok(players);
        }

        [HttpGet("League")]
        public async Task<IActionResult> PlayersForLeague([FromQuery] SortQuerryModel model)
        {
           var players = await statisticsService.PlayersForLeague(model.Id, model.Sort);

           //players = players.OrderByDescending(l => l.GetType().GetProperty(model.Sort).GetValue(l));

           return Ok(players);
        }
    }
}
