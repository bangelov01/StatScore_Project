export function setUpUserNav() {
    
    const token = sessionStorage.getItem('userToken');
    const username = sessionStorage.getItem('username');

    if (token !== null) {
        const els = document.querySelectorAll(".guest"); //todo
        document.querySelector(".profile span").textContent = `Welcome, ${email}`
        document.querySelector('.user').setAttribute('style', 'display:block');
        document.querySelector('.guest').setAttribute('style', 'display:none');
    } else {
        document.querySelector('.user').setAttribute('style', 'display:none');
        document.querySelector('.guest').setAttribute('style', 'display:block');
    }
}