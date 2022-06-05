namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerLeagueService playerLeagueService;

        public PlayersController(IPlayerLeagueService playerLeagueService)
        {
            this.playerLeagueService = playerLeagueService;
        }

        [HttpGet("Top/{count}")]
        public async Task<IActionResult> GetTopPlayers(int count)
        {
            try
            {
                var players = await playerLeagueService.TopPlayersAccrossLeagues(count);

                return Ok(players);
            }
            catch
            {
                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
