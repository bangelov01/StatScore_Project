import { playersTemplate } from "../templates/playersTemplate.js"
import { getPlayersForLeague, getLeaguesBasicInfo } from "../api/data.js"


export async function playersPage(ctx) {

    const token = sessionStorage.getItem("userToken");

    if (token === null) {
        alert("You need to be a user to access this page!");
        return ctx.page.redirect("/login");
    }

    let leagueId = 1;

    const defaultOrder = "Goals";

    const leagueInfo = await getLeaguesBasicInfo(1);

    const initialPlayers = await getPlayersForLeague(1, defaultOrder);

    ctx.render(playersTemplate(onClickLeagues, onClickSort, leagueInfo, initialPlayers));

    async function onClickLeagues(e) {

        if(e.target.tagName.toLowerCase() === "h5") {

            document.querySelector("button").textContent = e.target.textContent

            leagueId = e.target.id;
    
            const players = await getPlayersForLeague(e.target.id, defaultOrder);
    
            ctx.render(playersTemplate(onClickLeagues, onClickSort, leagueInfo, players));
        }
    }

    async function onClickSort(e) {

        if(e.target.textContent == "Goals" 
        || e.target.textContent == "Assists" 
        || e.target.textContent == "Appearences") {

            const sorted = await getPlayersForLeague(leagueId, e.target.textContent)

            ctx.render(playersTemplate(onClickLeagues, onClickSort, leagueInfo, sorted));
        }
    }
}