export interface IUserResponse {
    'id': number,
    'email': string,
    'first_name': string,
    'last_name': string,
    'avatar': string
    'job':string
}

export interface INewUserResponse {
    'name': string,
    'job': string,
    'id': number,
    'createdAt': string
}

export interface IUpdateResponse {
    'name': string,
    'job': string,    
    'updatedAt': string
}
