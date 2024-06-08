import { makeAutoObservable} from "mobx";
import * as apiUser from "../../../api/moduls/user";
import { INewUserResponse } from "../../../api/response/userResponse";

class CreateUserStore{

    job = '';
    name = '';
    
    responce: INewUserResponse = {        
        name: "",
        job: "",
        id: 0,
        createdAt: "",
    };    

    constructor(){
        makeAutoObservable(this);              
    };

    chageJob(job:string){
        this.job = job;        
    };

    changeName(name:string){
        this.name = name; 
    };    

    createUser = async() => {
        try {            
            const responce:INewUserResponse = await apiUser.createUser(this.name, this.job);           
            this.responce = responce;
            alert(this.responce.createdAt + "   " + this.responce.id)             
        }
        catch (e) {
            if (e instanceof Error) {
                alert(e.message)
            }
        }               
    };
}    

export default CreateUserStore;