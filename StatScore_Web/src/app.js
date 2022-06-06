import page from "../node_modules/page/page.mjs"
import { render } from "../node_modules/lit-html/lit-html.js"

import { setUpUserNav } from "./navigation/navigation.js"

import { registerPage } from "./views/register.js"

const main = document.querySelector("main");

page("/register", middleWareRender, registerPage);

setUpUserNav();
page.start();


function middleWareRender(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUpUserNav = setUpUserNav;
    next();
}
