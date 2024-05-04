import React, {ReactElement, FC, useEffect, useState} from "react";
import {
    Box,
    Card,
    CardContent,
    CardMedia,
    CircularProgress,
    Container,
    Grid,
    Pagination,
    Typography
} from '@mui/material'
import * as userApi from "../../api/moduls/user";
import { IUserResponse } from "../../interfaces/userResponse";
import {useParams} from "react-router-dom";

const User: FC<any> = (): ReactElement => {
    const [user, setUser] = useState<IUserResponse | null>(null);
    const [isLoading, setisLoading] = useState<boolean>(false)
    const {id} = useParams();

    useEffect(() => {
        if(id) {
            const getUser = async () => {
                try {
                    setisLoading(true);
                    const respon = await userApi.getUserById(id)
                    setUser(respon.data)
                } catch (error) {
                    if (error instanceof Error) {
                        console.error(error.message)
                    }
                }
                setisLoading(false);
            }
            getUser()
        }
    }, [id])

    return (
        <Container>
            <Grid container spacing={3} justifyContent='center' m={4}>
                {isLoading ? (
                    <CircularProgress/>
                    
                ) : (
                    <>
                    <Card sx={{ maxWidth: 250}}>
                        <CardMedia
                            component='img'
                            height='250'
                            image={user?.avatar}
                            alt={user?.first_name}
                        />
                        <CardContent>
                            <Typography noWrap gutterBottom variant="h6" component='div'>
                                {user?.first_name} {user?.last_name}
                            </Typography>
                            <Typography variant="body2" color="text.secondary">
                                {user?.email}
                            </Typography>
                        </CardContent>
                    </Card>
                    </>
                )}
            </Grid>
        </Container>
    );
}

export default User;