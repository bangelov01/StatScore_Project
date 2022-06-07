import { getTopTeams, getTopPlayers } from "../api/data.js"
import { topTemplate } from "../templates/topTemplate.js"

export async function homePage(ctx) {

    const numberOfTeams = 4;
    const numberOfPlayers = 4;

    const teams = await getTopTeams(numberOfTeams);
    const players = await getTopPlayers(numberOfPlayers);

    console.log(players)

    ctx.render(topTemplate(teams, players));
}