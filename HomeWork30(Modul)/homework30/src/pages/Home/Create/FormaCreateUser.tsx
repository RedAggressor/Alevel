import { FC, ReactElement} from "react";
import { Box, Button, Container,TextField, Typography } from "@mui/material";
import { observer } from "mobx-react";
import CreateUserStore from "./CreateStore";


const FormaCreateUser: FC<any> = (): ReactElement => {    
    const store = new CreateUserStore();

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
                    Create User
                </Typography>
                <Box component="form"
                    onSubmit={async (event) =>
                    {
                        event.preventDefault();
                        await store.createUser();
                        store.showCreateUSer();           
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

export default observer(FormaCreateUser);