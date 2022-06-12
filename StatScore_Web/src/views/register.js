import { register } from "../api/data.js"
import { registerTemplate } from "../templates/registerTemplate.js"

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
            if(!email.match(/^[a-z0-9.]{1,64}@[a-z0-9.]{1,64}$/i)) {
                throw new Error ("Not a valid Email!");
            }
            if (password !== repeatPass) {
                throw new Error ("Passwords do not match!");
            }

            const result = await register(username, email, password);
            ctx.setUpUserNav();
            alert("Registration successfull!")
            ctx.page.redirect("/login")

        } catch(error) {
            alert(error.message)
        }
    }
}