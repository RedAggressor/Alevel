export interface IUser {
    id: number;
    email: string;
    first_name: string;
    last_name: string;
    avatar: string;
  }

  export interface ICreateUser {
    name: string,
    job: string,    
    id: number,
    createdAt: string
  }

  export interface IUpdateUser {
    name: string,
    job: string,         
    updatedAt: string
  }