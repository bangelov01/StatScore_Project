import { getLeaguesBasicInfo } from "../api/data.js"

async function setUpUserNav() {
    
    const token = sessionStorage.getItem('userToken');
    const username = sessionStorage.getItem('username');

    const guestEls = document.querySelectorAll(".guest");
    const userEls = document.querySelectorAll(".user");

    const userSpan = document.querySelector(".user-span");

    if (token !== null) {
        userSpan.textContent = ` : ${username}`;
        userEls.forEach(e => e.setAttribute('style', 'display: block'));
        guestEls.forEach(e => e.setAttribute('style', 'display: none'));
    } else {
        userSpan.textContent = "";
        userEls.forEach(e => e.setAttribute('style', 'display: none'));
        guestEls.forEach(e => e.setAttribute('style', 'display: block'));
    }
}

async function SetLeaguesDropdown() {

    const leaguesBasic = await getLeaguesBasicInfo();
 
    const el = document.querySelector(".dropdown ul");
 
    leaguesBasic.forEach(e => {
       let li = document.createElement("li");
       let a = document.createElement("a");
 
       a.setAttribute("href", `/league/${e.id}`);
       a.textContent = e.name;
 
       li.appendChild(a);
       el.appendChild(li);
    });
}

export {
    setUpUserNav,
    SetLeaguesDropdown
}