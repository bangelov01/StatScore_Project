import { playersTemplate } from "../templates/playersTemplate.js"
import { getPlayersForLeague, getLeaguesBasicInfo } from "../api/data.js"


export async function playersPage(ctx) {

    const token = sessionStorage.getItem("userToken");

    if (token == null) {
        alert("You need to be a user to access this page!");
        ctx.page.redirect("/register");
    }

    const result = await getLeaguesBasicInfo(1);
    ctx.render(playersTemplate(onClick, result, {}));

    async function onClick(e) {

        const players = await getPlayersForLeague(e.target.id);

        ctx.render(playersTemplate(onClick, result, players));
    }
}