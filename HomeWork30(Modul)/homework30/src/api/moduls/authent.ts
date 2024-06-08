import apiClient from "../client";

export const login = ({ email, password }:{ email:string, password:string }) => apiClient({
    path: 'login',
    method: 'POST',
    data: {email, password}
})

export const registration = ({email, password} : {email:string, password:string}) => apiClient({
    path: `register`,
    method: 'POST',
    data: {email, password}
})