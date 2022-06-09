import { html } from "../../node_modules/lit-html/lit-html.js"

export const leagueTemplate = (leagueInfo, leagueStats) => html`
<section id="league">
<div class="cards-league">
<img src="${leagueInfo.logoURL}" class="img-league" alt="...">
<h4 class="info-h4">
<span>Country: ${leagueInfo.countryName}</span>
<span>Season: ${leagueInfo.season}</span></h4>
<div class="league card bg-light shadow">
   <h4 class="league-h4">Current <span>Table</span></h4>
   <div class="card-body text-center">
      <table class="table table-hover">
         <thead>
            <tr>
               <th scope="col">P.</th>
               <th scope="col">Team</th>
               <th scope="col">Wins</th>
               <th scope="col">Draws</th>
               <th scope="col">Losses</th>
               <th scope="col">G/D</th>
               <th scope="col">Win Ratio</th>
            </tr>
         </thead>
         <tbody>
         ${leagueStats.map(tableTemplate, 0)}
         </tbody>
      </table>
   </div>
</div>
<div class="league card bg-light shadow">
   <h4 class="league-h4">Last Five Games</h4>
   <div class="card-body text-center">
      <table class="table table-hover">
         <thead>
            <tr>
               <th scope="col">P.</th>
               <th scope="col">Team</th>
               <th scope="col">Wins</th>
               <th scope="col">Draws</th>
               <th scope="col">Losses</th>
            </tr>
         </thead>
         <tbody>
            <tr>
               <th scope="row">1</th>
               <td>Chelsea</td>
               <td>24</td>
               <td>4</td>
               <td>3</td>
            </tr>
            <tr>
               <th scope="row">2</th>
               <td>Arsenal</td>
               <td>Thornton</td>
            </tr>
            <tr>
               <th scope="row">3</th>
               <td>Man. City</td>
            </tr>
         </tbody>
      </table>
   </div>
   <div class="card-body">
      <a href="#" class="card-link">Card link</a>
      <a href="#" class="card-link">Another link</a>
   </div>
</div>
</div>
</section>
`;

const tableTemplate = (team, index) => html`
<tr>
   <th scope="row">${++index}<span class="span-icon"><img src="${team.logoURL}" style="width: 23px; height:30px;"></img></span></th>
   <td>${team.teamName}</td>
   <td>${team.wins}</td>
   <td>${team.draws}</td>
   <td>${team.losses}</td>
   <td>${(team.goalsAquired - team.goalsConceded)}</td>
   <td>${team.winRate}%</td>
</tr>
`