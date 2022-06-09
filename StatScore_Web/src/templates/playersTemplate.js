import { html } from "../../node_modules/lit-html/lit-html.js"

export const playersTemplate = (onclick, leagueInfo, players) => html`

<section id="league-player-drop">
<div class="btn-group">
  <button class="btn btn-secondary btn-lg dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
    Large button
  </button>
  <ul class="dropdown-menu">
    ${leagueInfo.map((l) => html`<li><a id="${l.id}" @click=${onclick}>${l.name}</a></li>`)}
  </ul>
</div>
${Object.keys(players).length == 0 ? html`<h4>OBJECT IS NULL</h4>` : html`<h4>OBJECT IS not NULL</h4>`}
</section>
`;

const playersTableTemplate = () => html``