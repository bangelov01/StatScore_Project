import { html } from "../../node_modules/lit-html/lit-html.js"
import { register } from "../api/data.js"


const registerTemplate = (onSubmit) => html`
<section id="register">
<form id="register-form" @submit=${onSubmit}>
    <div class="container login">
        <h1 class="display-4 fst-italic">Register</h1>
        <label for="username">Username</label>
        <input id="username" type="text" placeholder="Enter Username" name="username">
        <label for="email">Email</label>
        <input id="email" type="text" placeholder="Enter Email" name="email">
        <label for="password">Password</label>
        <input id="password" type="password" placeholder="Enter Password" name="password">
        <label for="repeatPass">Repeat Password</label>
        <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
        <input type="submit" class="registerbtn button" value="Register">
        <div class="container reg">
            <p>Already have an account?<a href="/login">Sign in</a>.</p>
        </div>
    </div>
</form>
</section>
`;

export async function registerPage(ctx) {

    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);

        const username = formData.get("username");
        const email = formData.get("email");
        const password = formData.get("password");
        const repeatPass = formData.get("repeatPass");

        try{

            if (username == '' || email == '' || password == "" || repeatPass == '') {
                throw new Error ("Fields must not be empty!");
            }
            if (password !== repeatPass) {
                throw new Error ("Passwords do not match!");
            }

            await register(username, email, password);
            ctx.setUpUserNav();
            alert("Registration successfull!")
            ctx.page.redirect("/login")

        } catch(error) {
            alert(error.message)
        }
    }
}