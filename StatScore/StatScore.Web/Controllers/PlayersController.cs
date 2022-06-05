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

        [HttpGet("Top")]
        public async Task<IActionResult> GetTopFourPlayers()
        {
            try
            {
                var players = await playerLeagueService.TopFourPlayersAccrossLeagues();

                return Ok(players);
            }
            catch
            {
                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
