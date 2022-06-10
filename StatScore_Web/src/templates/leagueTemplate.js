import { html } from "../../node_modules/lit-html/lit-html.js"

export const leagueTemplate = (leagueInfo, leagueStats, leagueGames) => html`
<section id="league">
<div class="cards-league">
<img src="${leagueInfo.logoURL}" class="img-league" alt="...">
<h4 class="info-h4">
<span>Country: ${leagueInfo.countryName}</span>
<span>Season: ${leagueInfo.season}</span></h4>
<div class="league card bg-light shadow">
   <h4 class="league-h4">Current <span>Table</span></h4>
   <div class="card-body text-center fst-italic">
      <table class="table table-hover">
         <thead>
            <tr>
               <th scope="col">P.</th>
               <th scope="col">Team</th>
               <th scope="col">Wins</th>
               <th scope="col">Draws</th>
               <th scope="col">Losses</th>
               <th scope="col">Points</th>
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
<h4 class="league-h4">Last <span>Five</span> Games</h4>
<div class="game card bg-light shadow">
   <div class="card-body fst-italic">
   <table class="table table-hover">
   <thead>
      <tr>
         <th scope="col"><h5>Home</h5></th>
         <th scope="col"><h5>Away</h5></th>
      </tr>
   </thead>
   <tbody>
   ${leagueGames.map(gamesTemplate)}
   </tbody>
</table>
   </div>
</div>
</div>
</section>
`;

const tableTemplate = (team, index) => html`
<tr>
   <th scope="row">${++index}<span class="span-icon"><img src="${team.logoURL}" class="table-logo"></img></span></th>
   <td>${team.teamName}</td>
   <td>${team.wins}</td>
   <td>${team.draws}</td>
   <td>${team.losses}</td>
   <td>${team.points}</td>
   <td>${(team.goalsAquired - team.goalsConceded)}</td>
   <td>${team.winRate}%</td>
</tr>
`

const gamesTemplate = (game) => html`
<tr class="games-row">
   <td>
      <div class="home-name">
         <span><h5>${game.homeTeamName}</h5></span>
         <span style="float: right;"><img src="${game.homeLogoURL}" class="table-logo-game" style="margin-right: 10px;"></img>${game.homeTeamGoals}</span>
      </div>
      <div class="home-details">
         <p>Shots: <span>${game.homeTeamShots}</span></p>
         <p>Passes: <span>${game.homeTeamPasses}</span></p>
         <p>Fauls: <span>${game.homeTeamFauls}</span></p>
      </div>
   </td>
   <td>
      <span style="margin-left:15px; font-size: 20px">:</span>
      <div class="away-name">
         <span><h5>${game.awayTeamName}</h5></span>
         <span style="float: left;">${game.awayTeamGoals}<img src="${game.awayLogoURL}" class="table-logo-game"></img></span>
      </div>
      <div class="away-details">
         <p>Shots: <span>${game.awayTeamShots}</span></p>
         <p>Passes: <span>${game.awayTeamPasses}</span></p>
         <p>Fauls: <span>${game.awayTeamFauls}</span></p>
      </div>         
   </td>
</tr>
`