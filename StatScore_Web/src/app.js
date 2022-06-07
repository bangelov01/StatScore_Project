import page from "../node_modules/page/page.mjs"
import { render } from "../node_modules/lit-html/lit-html.js"

import { setUpUserNav } from "./navigation/navigation.js"
import { logout } from "./api/data.js"

import { registerPage } from "./views/register.js"
import { loginPage } from "./views/login.js"
import { homePage } from "./views/home.js"
import { leaguePage } from "./views/league.js"

const main = document.querySelector("main");

page("/", middleWareRender, homePage);
page("/register", middleWareRender, registerPage);
page("/login", middleWareRender, loginPage);
page("/league/:id", middleWareRender, leaguePage);

setUpUserNav();
page.start();


function middleWareRender(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUpUserNav = setUpUserNav;
    next();
}

document.getElementById('logoutBtn').addEventListener('click', () => {
    logout();
    setUpUserNav();
    page.redirect("/");
});
