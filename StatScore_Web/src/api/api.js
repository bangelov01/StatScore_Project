const settings = {
    host: ""
}

async function get(url) {
    return request(url, options());
}

async function post(url, data) {
    return request(url, options("POST", data));
}

async function register(username, email, password) {

    const response = await post(settings.host + "/api/Authentication/Register", {username, email, password});

    return response;
}

async function login(username, password) {

    const response = await post(settings.host + "/api/Authentication/Login", {username, password});

    sessionStorage.setItem("userToken", response.token);
    sessionStorage.setItem("userId", response.id);
    sessionStorage.setItem("username", response.userName);
    sessionStorage.setItem("tokenExpiration", response.expiration);

    return response;
}

function logout(){

    sessionStorage.removeItem("userToken");
    sessionStorage.removeItem("userId");
    sessionStorage.removeItem("username");
    sessionStorage.removeItem("tokenExpiration");
}

async function request(url, options) {

    try {
        const response = await fetch(url, options);

        if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }

        try {
            
            return await response.json();

        } catch (error) {
            
            return response;
        }
        
    } catch (error) {
        throw error;
    }
}

function options(method = "GET", data) {

    const result = {
        method,
        headers: {}
    }

    if (data) {
        result.headers["Content-Type"] = "application/json";
        result.body = JSON.stringify(data);
    }

    const token = sessionStorage.getItem("userToken");
    if (token !== null) {
        result.headers["Authorization"] = "Bearer " + token;
    }

    return result;
}

export {
    get,
    post,
    register,
    login,
    logout,
    settings
}