import apiClient from "./apiClient";

export const getUserById = async (id:number) => apiClient({   
    pathSector:`users/${id}`,
    method:'GET'
});

export const getuserByPage = async (page:number) => apiClient({
    pathSector: `users?page=${page}`,
    method: 'GET'
})


