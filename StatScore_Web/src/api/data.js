import * as api from "./api.js"

const host = "https://localhost:44395";
api.settings.host = host;

export const register = api.register;
export const login = api.login;
export const logout = api.logout;

async function getTopTeams(count) {
    return await api.get(host + "/api/Teams/Top/" + count);
}

async function getTopPlayers(count) {
    return await api.get(host + "/api/Players/Top/" + count);
}

async function getLeagueFullInfo(id) {
    return await api.get(host + "/api/Leagues/" + id);
}

async function getLeagueStats(id) {
    return await api.get(host + "/api/Leagues/Stats/" + id);
}

async function getLeaguesBasicInfo() {
    return await api.get(host + "/api/Leagues/");
}

export {
    getTopTeams,
    getTopPlayers,
    getLeagueFullInfo,
    getLeagueStats,
    getLeaguesBasicInfo
}