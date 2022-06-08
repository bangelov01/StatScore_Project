import { getTopTeams, getTopPlayers, getLeaguesBasicInfo } from "../api/data.js"
import { topTemplate } from "../templates/topTemplate.js"

export async function homePage(ctx) {

    const numberOfTeams = 4;
    const numberOfPlayers = 4;

    const teams = await getTopTeams(numberOfTeams);
    const players = await getTopPlayers(numberOfPlayers);

    ctx.render(topTemplate(teams, players));
}