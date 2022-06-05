namespace StatScore.Web.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models;

    [Route("api/[Controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILeagueService leagueService;
        private readonly IGameService gameService;

        public TestController(ILeagueService leagueService, IGameService gameService)
        {
            this.leagueService = leagueService;
            this.gameService = gameService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type =  typeof(LeagueInfoServiceModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLeagueById(int id)
        {
            var league = await leagueService.LeagueInfo(id);

            if (league == null) return BadRequest();

            return Ok(league);
        }
    }
}
