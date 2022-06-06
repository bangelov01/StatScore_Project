export function setUpUserNav() {
    
    const token = sessionStorage.getItem('userToken');
    const username = sessionStorage.getItem('username');

    if (token !== null) {
        document.querySelector(".navbar-collapse span").textContent = `Welcome, ${username}`
        document.querySelector('.user').setAttribute('style', 'display: inline');
        document.querySelector('.guest').setAttribute('style', 'display:none');
    } else {
        document.querySelector('.user').setAttribute('style', 'display: none');
        document.querySelector('.guest').setAttribute('style', 'display: inline');
    }
}