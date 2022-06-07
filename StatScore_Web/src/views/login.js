import { html } from "../../node_modules/lit-html/lit-html.js"
import { login } from "../api/data.js"

const loginTemplate = (onSubmit) => html`
<section id="login">
<form id="register-form" @submit=${onSubmit}>
    <div class="container login fst-italic">
        <h1 class="display-4">Login</h1>
        <label for="username">Username</label>
        <input id="username" placeholder="Enter Username" name="username" type="text">
        <label for="password">Password</label>
        <input id="password" type="password" placeholder="Enter Password" name="password">
        <input type="submit" class="registerbtn button" value="Login">
        <div class="container reg">
            <p>Dont have an account?<a href="/register">Sign up</a>.</p>
        </div>  
    </div>
</form>
</section>
`;

export async function loginPage(ctx) {

    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const username = formData.get("username");
        const password = formData.get("password");

        try {

            if (username == '' || password == '') {
                throw new Error ("Fields must not be empty!")
            }

            await login(username, password);
            ctx.setUpUserNav();
            ctx.page.redirect("/");

        } catch (error) {
            alert(error.message);
        }
    }
}