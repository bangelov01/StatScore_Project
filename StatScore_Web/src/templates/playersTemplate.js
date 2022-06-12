import { html } from "../../node_modules/lit-html/lit-html.js"

export const playersTemplate = (onclick, onClickSort, leagueInfo, players) => html`
<section id="league-player-drop">
   <div class="welcome text-center mt-4">
      <h1>Players <span>Stats</span></h1>
         <div class="btn-group">
         <button class="btn btn-lg dropdown-toggle type="button" data-bs-toggle="dropdown" aria-expanded="false">
         ${leagueInfo[0].name}
         </button>
         <ul class="dropdown-menu" @click=${onclick}>
            ${leagueInfo.map((l) => html`
            <li><h5 id="${l.id}">${l.name}</h5></li>
            `)}
         </ul>
      </div>
   </div>
   ${tableTemplate(onClickSort, players)}
</section>
`;

const tableTemplate = (onClickSort, players) => html`
<div class="player card bg-light shadow">
<div class="card-body text-center">
    <p>*Players can be sorted by Goals/Assists or Appearences.</p>
    <table class="table table-hover">
      <thead>
          <tr @click=${onClickSort}>
            <th scope="col">Name</th>
            <th scope="col">Team</th>
            <th class="sort" scope="col">Goals</th>
            <th class="sort" scope="col">Assists</th>
            <th class="sort" scope="col">Appearences</th>
            <th scope="col">Position</th>
            <th scope="col">Injured</th>
          </tr>
      </thead>
      <tbody>
          ${players.map(playersTableTemplate)}
      </tbody>
    </table>
</div>
</div>
`

const playersTableTemplate = (player) => html`
<tr>
   <td><h6>${player.firstName + " " + player.lastName}</h6></td>
   <td><img src="${player.teamLogo}" class="table-logo"></td>
   <td>${player.goals}</td>
   <td>${player.assists}</td>
   <td>${player.appearences}</td>
   <td>${player.position}</td>
   <td>${player.isInjured == true? "Yes" : "No"}</td>
</tr>
`