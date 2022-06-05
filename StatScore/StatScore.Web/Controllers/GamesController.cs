namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using StatScore.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService gameService;

        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet("League/{id}")]
        public async Task<IActionResult> GamesByLeague(int id)
        {
            try
            {
                var games = await gameService.GamesForLeague(id);

                return Ok(games);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
