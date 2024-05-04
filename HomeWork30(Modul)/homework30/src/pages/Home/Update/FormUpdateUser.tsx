import { FC, ReactElement} from "react";
import { Box, Button, Container,TextField, Typography } from "@mui/material";
import { observer } from "mobx-react";
import UpdateStore from "./UpdateStore";


const FormaUpdateUser: FC<any> = (): ReactElement => {    
    const store = new UpdateStore();

    return (
        <Container>
            <Box
                sx={{
                    marginTop: 8,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}
            >
                <Typography component="h1" variant="h5">
                    Update User
                </Typography>
                <Box component="form"
                    onSubmit={async (event) =>
                    {
                        event.preventDefault();
                        await store.updateUser();
                        store.showUpdateUser();           
                    }}
                >                      
                    <TextField
                        margin="normal"
                        required
                        fullWidth
                        name="name"
                        label="name"
                        type="string"                    
                        onChange={(event) => {store.changeName(event.target.value)}}                    
                    /> 
                    <TextField
                        margin="normal"
                        required
                        fullWidth                    
                        label="Job"
                        name="job"
                        type="string"                  
                        onChange={(event) => {store.chageJob(event.target.value)}}
                    />          
                    <Button
                        type="submit"
                        fullWidth
                        variant="contained"
                        sx={{ mt: 3, mb: 2 }}
                    >
                        Submit                 
                    </Button>
                </Box>
            </Box>  
        </Container>
    )
}

export default observer(FormaUpdateUser);