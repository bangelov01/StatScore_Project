import * as api from "./api.js"

const host = "https://localhost:44395";
api.settings.host = host;

async function getTopTeams(count) {
    return await api.get(host + "/api/Teams/Top/" + count);
}

export {
    getTopTeams,
}