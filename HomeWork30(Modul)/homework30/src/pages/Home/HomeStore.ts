import { makeAutoObservable, runInAction, } from "mobx";
import { IUserResponse } from "../../api/response/userResponse";
import * as userApi from "../../api/moduls/user";

class HomeStore {
    
    users: IUserResponse[] = [];
    totalPages = 0;
    currentPage = 1;
    isLoading = false;
    email = "";
    password = '';

    constructor()
    {
        makeAutoObservable(this);
        runInAction(this.prefetchData);
    }
    
    async changePage(page:number) {
        this.currentPage = page;
        await this.prefetchData();
    }

    prefetchData = async () => {
        try {
            this.isLoading = true;
            const respon = await userApi.getUserByPage(this.currentPage)
            this.users = respon.data;
            this.totalPages = respon.total_pages;
        }
        catch (error) {
            if(error instanceof Error) {
                console.error(error.message)   
            }
        }

        this.isLoading = false;
    };
}

export default HomeStore;