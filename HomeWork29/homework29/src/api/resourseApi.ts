import apiClient from "./apiClient";

export const getResouseById = async (id:number) => apiClient({   
    pathSector:`unknown/${id}`,
    method:'GET'
});

export const getResouseByPage = async (page:number) => apiClient({
    pathSector: `unknown?page=${page}`,
    method: 'GET'
})