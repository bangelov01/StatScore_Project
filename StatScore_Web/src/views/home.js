import { getTopTeams, getTopPlayers, getLeaguesBasicInfo } from "../api/data.js"
import { topTemplate } from "../templates/topTemplate.js"

export async function homePage(ctx) {

    const teams = await getTopTeams();
    const players = await getTopPlayers();

    ctx.render(topTemplate(teams, players));
}