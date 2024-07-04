import apiClient from "../client";

export const getProductById = (id: string) => apiClient({
    path:`unknown/${id}`,
    method:'GET'
})

export const getProductByPage = (page: number) => apiClient({
    path:`unknown?page=${page}`,
    method:'GET'
})