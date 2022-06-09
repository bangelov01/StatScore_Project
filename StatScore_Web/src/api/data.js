import * as api from "./api.js"

const host = "https://localhost:44395";
api.settings.host = host;

export const register = api.register;
export const login = api.login;
export const logout = api.logout;

async function getTopTeams() {
    return await api.get(host + "/Teams/Overall/");
}

async function getTopPlayers() {
    return await api.get(host + "/Players/Overall/");
}

async function getLeagueStats(id) {
    return await api.get(host + "/Teams/League/" + id);
}

async function getLeaguesBasicInfo() {
    return await api.get(host + "/Leagues/");
}

async function getLeagueFullInfo(id) {
    return await api.get(host + "/Leagues/" + id);
}

async function getGamesForLeague(id) {
    return await api.get(host + "/Games/League/" + id);
}

async function getPlayersForLeague(id) {
    return await api.get(host + "/Players/League/" + id);
}

export {
    getTopTeams,
    getTopPlayers,
    getLeagueFullInfo,
    getLeagueStats,
    getLeaguesBasicInfo,
    getGamesForLeague,
    getPlayersForLeague
}