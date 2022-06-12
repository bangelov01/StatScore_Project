import { html } from "../../node_modules/lit-html/lit-html.js"

export const loginTemplate = (onSubmit) => html`
<section id="login">
<form id="register-form" @submit=${onSubmit}>
    <div class="container login">
        <h1 class="fst-italic">Login</h1>
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