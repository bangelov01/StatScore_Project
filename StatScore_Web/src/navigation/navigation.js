import { getLeaguesBasicInfo } from "../api/data.js"

export async function setUpUserNav() {
    
    const token = sessionStorage.getItem('userToken');
    const username = sessionStorage.getItem('username');

    const guestEls = document.querySelectorAll(".guest");
    const userEls = document.querySelectorAll(".user");
    const userSpan = document.querySelector(".user-span");

    if (token !== null) {
        //guestEls.forEach(e => e.setAttribute('style', 'display:none'));
        userSpan.textContent = ` : ${username}`;
        document.querySelector('.user').setAttribute('style', 'display:block');
        userEls.forEach(e => e.setAttribute('style', 'display: block'));
        //document.querySelector('.guest').setAttribute('style', 'display:none');
    } else {
        //document.querySelector('.user').setAttribute('style', 'display:none');
        userSpan.textContent = "";
        guestEls.forEach(e => e.setAttribute('style', 'display: block'));
        userEls.forEach(e => e.setAttribute('style', 'display: none'));
    }

    await SetLeaguesDropdown();
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