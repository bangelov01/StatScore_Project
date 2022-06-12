import { html } from "../../node_modules/lit-html/lit-html.js"

const topTemplate = (teams, players) => html`
<section id="welcome">
   <div class="welcome text-center mt-4">
      <h1>Welcome to <span>StatScore</span></h1>
      <h2>Your daily stat checker</h2>
   </div>
   <div class="container home">
      <div class="row row-cols-1 row-cols-md-2 g-4">
         <div class="col">
            <div class="card bg-light shadow" style="width: 40rem; border-radius: 4%;">
               <div class="card-body text-center">
                  <h5 class="card-title fst-italic display-6 fw-bold">Top Performing Teams</h5>
                  <h4>Across all leagues</h4>
                  <table class="table table-hover">
                     <thead>
                        <tr>
                           <th scope="col">P.</th>
                           <th scope="col">Team</th>
                           <th scope="col">Wins</th>
                           <th scope="col">Draws</th>
                           <th scope="col">Losses</th>
                           <th scope="col">Win Ratio</th>
                        </tr>
                     </thead>
                     <tbody>
                     ${teams.map(topTeamsTemplate, 0)}
                     </tbody>
                  </table>
               </div>
            </div>
         </div>
         <div class="col col-centered">
            <div class="card bg-light shadow" style="width: 40rem; border-radius: 4%;">
               <div class="card-body text-center">
                  <h5 class="card-title fst-italic display-6 fw-bold">Top Performing Players</h5>
                  <h4>Across all leagues</h4>
                  <table class="table table-hover">
                     <thead>
                        <tr>
                           <th scope="col">P.</th>
                           <th scope="col">Name</th>
                           <th scope="col">Goals</th>
                           <th scope="col">Assists</th>
                           <th scope="col">Apps.</th>
                        </tr>
                     </thead>
                     <tbody>
                     ${players.map(topPlayersTemplate, 0)}
                     </tbody>
                  </table>
               </div>
               <div class="bottom card-body text-center">
                  ${sessionStorage.getItem("userToken") == null ? html`<h5>To view more details - <a href="/login">Log In now.</a></h5>` : ""}
               </div>
            </div>
         </div>
      </div>
   </div>
</section>
`;

const topTeamsTemplate = (team, index) => html`
<tr>
   <th scope="row">${++index}</th>
   <td><span>${team.teamName}</span></td>
   <td>${team.wins}</td>
   <td>${team.draws}</td>
   <td>${team.losses}</td>
   <td>${team.winRate}%</td>
</tr>
`; 

const topPlayersTemplate = (player, index) => html`
<tr>
   <th scope="row">${++index}</th>
   <td>${player.firstName + " " + player.lastName}</td>
   <td>${player.goals}</td>
   <td>${player.assists}</td>
   <td>${player.appearences}</td>
</tr> 
`;

export {
   topTemplate
}