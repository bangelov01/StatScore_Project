import { getLeagueInfo, getLeagueStats } from "../api/data.js"
import { leagueTemplate } from "../templates/leagueTemplate.js"


export async function leaguePage(ctx) {

    const leagueId = ctx.params.id;

    const leagueInfo = await getLeagueInfo(leagueId);
    const leagueStats = await getLeagueStats(leagueId);

    ctx.render(leagueTemplate(leagueInfo, leagueStats))
}