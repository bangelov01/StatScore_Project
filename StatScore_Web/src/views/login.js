import { login } from "../api/data.js"
import { loginTemplate } from "../templates/loginTemplate.js"



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