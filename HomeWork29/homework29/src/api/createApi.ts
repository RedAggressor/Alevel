import apiClient from "./apiClient";

export const create = async ({name, job}:{name:string, job:string}) => apiClient({
    pathSector: `users`,
    method: `POST`,
    data: {name, job}
})