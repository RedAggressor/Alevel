import {FC} from "react";
import Resourses from "./Resourse/ResoursesTabs";
import VerticalTabs from "./Navigation/TabsNav";

interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<{}>
}

export const routes: Array<Route> = [      
    {
        key: 'user-route',
        title: 'User',
        path: '/',
        enabled: true,
        component: VerticalTabs
    },
    {
        key: 'products-route',
        title: 'Products',
        path: '/products',
        enabled: true,
        component: Resourses
    },
    
]