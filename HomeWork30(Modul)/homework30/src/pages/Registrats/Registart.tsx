import {useContext} from 'react'
import {Box, Button, CircularProgress, TextField, Typography} from '@mui/material'
import RegistratStore from './RegistratStore';
import {AppStoreContext} from "../../App";
import {observer} from "mobx-react-lite";

const Registart = () => {
    const appStore = useContext(AppStoreContext);
    const store = new RegistratStore(appStore.authStore);

    return (
        <Box
            sx={{
                marginTop: 8,
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
            }}
        >
            <Typography component="h1" variant="h5">
                Registration
            </Typography>
            <Box component="form"
                 onSubmit={async (event) =>
                 {
                     event.preventDefault();
                     await store.registrat();
                     (!!appStore.authStore.token) ?
                     alert(`registartion succesfull your token: ${appStore.authStore.token}`)
                     :
                     alert(store.error);
                }}
                 >
                <TextField
                    type="email"
                    margin="normal"
                    required
                    fullWidth
                    id="email"
                    label="Email Address"
                    name="email"
                    autoComplete="email"
                    onChange={(event) => 
                        store.changeEmail(event.target.value)}
                    autoFocus
                />
                <TextField                    
                    margin="normal"
                    required
                    fullWidth
                    name="password"
                    label="Password"
                    type="password"
                    id="password"
                    onChange={(event) =>
                         store.changePassword(event.target.value)}
                    autoComplete="current-password"
                />
                {!!store.error && (
                    <p style={{ color: 'red', fontSize: 14 }}>{store.error}</p>
                )}
                <Button
                    type="submit"
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2 }}
                >
                    {store.isLoading ? (
                        <CircularProgress />
                    ) : (
                        'Submit'
                    )}
                </Button>                
            </Box>
        </Box>
    )
}

export default observer(Registart)