import apiClient from "../client";

export const getUserById = (id: string) => apiClient({
    path:`users/${id}`,
    method:'GET',
})

export const getUserByPage = (page: number) => apiClient({
    path:`users?page=${page}`,
    method:'GET',
})

export const createUser = (name:string, job:string) => apiClient({
    path:`users`,
    method: `POST`,
    data: {name, job}
})

export const updateUser = (name: string, job:string, id:number) => apiClient({
    path:`users/${id}`,
    method: `PUT`,
    data: {name, job}
})