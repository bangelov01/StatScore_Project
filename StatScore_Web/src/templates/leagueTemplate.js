import { html } from "../../node_modules/lit-html/lit-html.js"

export const leagueTemplate = (leagueInfo, leagueStats) => html`
<h5>Hello from league - ${leagueInfo.name}</h5>
`;