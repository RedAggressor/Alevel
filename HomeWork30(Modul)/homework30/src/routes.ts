import Home from "./pages/Home/Home";
import { FC } from "react";
import User from "./pages/User/User";
import Product from "./pages/Product/Product";
import Login from "./pages/Login/Login";
import Resource from "./pages/Resource/Resourse";
import Registart from "./pages/Registrats/Registart";

interface IRoute{
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<{}>
}

const check = false;

export const routes: Array<IRoute> = [
    {
        key: 'home-route',
        title: 'Home',
        path: '/',
        enabled: true,
        component: Home
    },
    {
        key: 'user-route',
        title: 'User',
        path: '/user/:id',
        enabled: false,
        component: User
    },
    {
        key: 'products-route',
        title: 'Products',
        path: '/products',
        enabled: true,
        component: Product
    },    
    {
        key: 'login-route',
        title: 'Login',
        path: '/login',
        enabled: true,
        component: Login
    },    
    {
        key: 'resourse-route',
        title: 'Resourse',
        path: '/resourse/:id',
        enabled: false,
        component: Resource
    },
    {
        key: 'register-route',
        title: 'Registartion',
        path: '/register',
        enabled: true,
        component: Registart
    },    
]