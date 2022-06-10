import { playersTemplate } from "../templates/playersTemplate.js"
import { getPlayersForLeague, getLeaguesBasicInfo } from "../api/data.js"


export async function playersPage(ctx) {

    const token = sessionStorage.getItem("userToken");

    if (token === null) {
        alert("You need to be a user to access this page!");
        return ctx.page.redirect("/login");
    }

    const result = await getLeaguesBasicInfo(1);
    ctx.render(playersTemplate(onClickLeagues, onClickSort, result, {}));

    async function onClickLeagues(e) {

        document.querySelector("button").textContent = e.target.textContent

        const players = await getPlayersForLeague(e.target.id, "Goals");

        ctx.render(playersTemplate(onClickLeagues, onClickSort, result, players));
    }

    async function onClickSort(e) {

        if(e.target.textContent == "Goals" 
        || e.target.textContent == "Assists" 
        || e.target.textContent == "Appearences") {
            console.log(e.target.textContent)
        }
    }
}