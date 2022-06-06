import { register, login } from "./api/api.js";
import { getTopTeams } from "./api/data.js"

//const response = await register("string", "user@example.com", "string");

const response = await login("string", "string");

const teams = await getTopTeams(4);

console.log(response);
console.log(teams);

