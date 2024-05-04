import { makeAutoObservable} from "mobx";
import * as apiUser from "../../../api/moduls/user";
import { IUpdateResponse } from "../../../api/response/userResponse";

class UpdateStore{

    job = '';
    name = '';   
    responce: IUpdateResponse = {name: "", job: "", updatedAt: ''};
    id = 2; // https://reqres.in/api/users/2 from PUT method

    constructor(){
        makeAutoObservable(this)        
    }

    chageJob(email:string){
        this.job = email;        
    }

    changeName(name:string){
        this.name = name;        
    }

    changeId(id:number){
        this.id = id
    }

    async updateUser() {
        try {            
            const responce = await apiUser.updateUser(this.name, this.job, this.id);
    
            this.responce = {
                name: responce.name,
                job: responce.job,               
                updatedAt: responce.updatedAt,
                
            }            
        }
        catch (e) {
            if (e instanceof Error) {
                alert(e.message)
            }
        }               
    }
    
    showUpdateUser(){
        alert(
        `    update user info        
        name: ${this.responce.name}
        job: ${this.responce.job}
        updatedAt: ${this.responce.updatedAt}
        `)
    }
}    

export default UpdateStore;
