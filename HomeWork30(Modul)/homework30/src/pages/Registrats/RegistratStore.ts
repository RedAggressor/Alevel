import { makeAutoObservable } from "mobx";
import AuthStore from "../../stores/AuthStore";

class RegistratStore {

    private authStore: AuthStore;

    email = '';
    password = '';
    error = '';
    isLoading = false;    

    constructor(authStore: AuthStore) {
        this.authStore = authStore;
        makeAutoObservable(this);
    }

    changeEmail(email: string) {
        this.email = email;
        if (!!this.error) {
            this.error = '';
        }
    }

    changePassword(password: string) {
        this.password = password;
        if (!!this.error) {
            this.error = '';
        }
    }

    async registrat() {
        try {
            this.isLoading = true;
           await this.authStore.login(this.email, this.password);
           
        }
        catch (e) {
            if (e instanceof Error) {
                this.error = e.message;
            }
        }
        this.isLoading = false;
    }
}

export default RegistratStore;