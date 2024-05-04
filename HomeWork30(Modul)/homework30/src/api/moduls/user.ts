import apiClient from "../client";

export const getUserById = (id: string) => apiClient({
    path:`users/${id}`,
    method:'GET'
})

export const getUserByPage = (page: number) => apiClient({
    path:`users?page=${page}`,
    method:'GET'
})