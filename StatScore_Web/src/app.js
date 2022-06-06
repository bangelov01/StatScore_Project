import { getTopTeams } from "./api/data.js"

let teams = await getTopTeams(3);

console.log(teams);

