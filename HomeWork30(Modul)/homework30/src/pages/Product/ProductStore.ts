import { makeAutoObservable, runInAction } from "mobx";
import * as resorceApi from "../../api/moduls/resours";
import { IResourseResponse } from "../../api/response/productResponce";
    
class ProductStore {
    resourse: IResourseResponse[] = [];
    totalPages = 0;
    currentPage = 1;
    isLoading = false;

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
            const respon = await resorceApi.getProductByPage(this.currentPage)
            this.resourse = respon.data;
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

    export default ProductStore;