import apiClient from "./apiClient";

export const update = async ({name, job}:{name:string, job:string} , id:string) => apiClient({
    pathSector: `users/${id}`,
    method: `PUT`,
    data: {name, job}
})