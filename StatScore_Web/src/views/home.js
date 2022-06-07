import { html } from "../../node_modules/lit-html/lit-html.js"

const topTeamsTemplate = html`
<div class="card bg-light shadow" style="width: 30rem; border-radius: 4%;">
    <img src="https://seeklogo.com/images/E/emirates-fa-cup-logo-4A51E1714E-seeklogo.com.png" class="card-img-top" alt="...">
    <div class="card-body text-center">
        <h5 class="card-title fst-italic display-6 fw-bold" style="color:#00aded">Current Standings</h5>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="col">P.</th>
                    <th scope="col">Team</th>
                    <th scope="col">Wins</th>
                    <th scope="col">Draws</th>
                    <th scope="col">Losses</th>
                   @* <th scope="col">Favorite</th>*@
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">1</th>
                    <td>Chelsea</td>
                    <td>24</td>
                    <td>4</td>
                    <td>3</td>
                    @*<td><button type="button" class="btn btn-primary">Favorite</button></td>*@
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
`; 

const homeTemplate = html`
<section id="welcome">
   <div class="text-center mt-4">
      <h1 class="display-3 text-white fst-italic shadow-text">Welcome to StatScore</h1>
      <p class="display-6 text-white fst-italic shadow-text">Your daily stat checker</p>
   </div>
   <div class="container home">
   <div class="row row-cols-1 row-cols-md-2 g-4">
   ${topTeamsTemplate}
   <div class="col">
      <div class="card">
         <img src="..." class="card-img-top" alt="...">
         <div class="card-body">
            <h5 class="card-title">Card title</h5>
            <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
         </div>
      </div>
   </div>
</div>
   </div>
</section>
`;
export async function homePage(ctx) {
    ctx.render(homeTemplate);
}