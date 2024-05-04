import { makeAutoObservable} from "mobx";
import * as apiUser from "../../../api/moduls/user";
import { INewUserResponse } from "../../../api/response/userResponse";

class CreateUserStore{

    job = '';
    name = '';   
    responce: INewUserResponse = {name: "", job: "", id: 0,  createdAt: ''};

    constructor(){
        makeAutoObservable(this)        
    }

    chageJob(email:string){
        this.job = email;        
    }

    changeName(name:string){
        this.name = name;        
    }

    async createUser() {
        try {            
            const responce = await apiUser.createUser(this.name, this.job);
    
            this.responce = {
                name: responce.name,
                job: responce.job,
                id: responce.id,
                createdAt: responce.createdAt,
            }            
        }
        catch (e) {
            if (e instanceof Error) {
                alert(e.message)
            }
        }
               
    }
    
    showCreateUSer(){
        alert(
        `    Create user info
        id:${this.responce.id}
        name: ${this.responce.name}
        job: ${this.responce.job}
        createAt: ${this.responce.createdAt}`)
    }
}    

export default CreateUserStore;