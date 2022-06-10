import { html } from "../../node_modules/lit-html/lit-html.js"

export const registerTemplate = (onSubmit) => html`
<section id="register">
<form id="register-form" @submit=${onSubmit}>
    <div class="container login">
        <h1 class="fst-italic">Register</h1>
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