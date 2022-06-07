export function setUpUserNav() {
    
    const token = sessionStorage.getItem('userToken');
    const username = sessionStorage.getItem('username');

    const guestEls = document.querySelectorAll(".guest");
    const userSpan = document.querySelector(".user-span");

    if (token !== null) {
        guestEls.forEach(e => e.setAttribute('style', 'display:none'));
        userSpan.textContent = ` : ${username}`;
        document.querySelector('.user').setAttribute('style', 'display:block');
        //document.querySelector('.guest').setAttribute('style', 'display:none');
    } else {
        document.querySelector('.user').setAttribute('style', 'display:none');
        userSpan.textContent = "";
        guestEls.forEach(e => e.setAttribute('style', 'display:block'));
    }
}