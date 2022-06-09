import { getLeagueFullInfo, getLeagueStats, getGamesForLeague} from "../api/data.js"
import { leagueTemplate } from "../templates/leagueTemplate.js"


export async function leaguePage(ctx) {

    const leagueId = ctx.params.id;

    console.log(leagueId)

    const leagueInfo = await getLeagueFullInfo(leagueId);
    const leagueStats = await getLeagueStats(leagueId);
    const leagueGames = await getGamesForLeague(leagueId);

    ctx.render(leagueTemplate(leagueInfo, leagueStats, leagueGames))
}