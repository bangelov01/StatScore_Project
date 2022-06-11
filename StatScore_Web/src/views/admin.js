import { adminTemplate } from "../templates/adminTemplate.js"



export async function adminPage(ctx) {

    if(sessionStorage.getItem("isAdmin") == null) {
        alert("You need to be an Admin to view this page!")
        return ctx.page.redirect("/");
    }
    
    ctx.render(adminTemplate);
}