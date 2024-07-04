import { FC, ReactElement, useState} from "react";
import { Box, Button, Card, CardContent, Container,Grid,TextField, Typography } from "@mui/material";
import { observer } from "mobx-react";
import CreateUserStore from "./CreateStore";

const store = new CreateUserStore(); 

const FormaCreateUser: FC<any> = (): ReactElement => {
    
    return (
        <Container>
            <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
                <Grid item xs={6}  >
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
                            onSubmit={ async (event) =>
                            {
                                event.preventDefault();
                                await store.createUser();                            
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
                </Grid>
                <Grid item xs={6} >
                    <Box 
                        sx={{ minWidth: 275,
                            marginTop: 8,
                            display: 'flex',
                            flexDirection: 'column',
                            alignItems: 'center',
                        }}
                    >
                        <Card >
                            <CardContent >
                                <Typography sx={{ mb: 1.5 }}  variant="h3" component="div" >
                                    Created user
                                </Typography>
                                <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                id: {store.responce.id} 
                                </Typography>
                                <Typography variant="h6" component="div">
                                name: {store.responce.name}
                                </Typography>
                                <Typography variant="h6" component="div">
                                job: {store.responce.job}
                                </Typography>
                                <Typography variant="body2">
                                createdAt: {store.responce.createdAt}              
                                </Typography>
                            </CardContent>
                        </Card>
                    </Box>
                </Grid>
            </Grid> 
        </Container>
    )
}

export default observer(FormaCreateUser);