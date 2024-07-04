const basePath = 'https://reqres.in/api/'

const chakResponse = async (responce:Response) => {
    if(!responce.ok){
        const message = await responce.json();
        throw Error(message.error|| 'bad Requst');        
    }
    return responce.json();
}


const apiClient = async ({pathSector, method, data}: apiClientProps) => {
    const requetOpntion ={
        method,
        headers: {'Content-Type': 'application/json'},
        body: !!data? JSON.stringify(data) : undefined
    }
        
    return fetch(`${basePath}${pathSector}`,  requetOpntion).then(respons => chakResponse(respons))
}

interface apiClientProps {
    pathSector: string,
    method: string,
    data?: any
}

export default apiClient;