import {ReactElement, FC, useEffect, useState} from "react";
import {
    Box,
    Card,
    CardContent,   
    CircularProgress,
    Container,
    Grid,   
    Typography
} from '@mui/material'
import * as resourseApi from "../../api/moduls/resours";
import { IResourseResponse } from "../../api/response/productResponce";
import {useParams} from "react-router-dom";

const Resource: FC<any> = (): ReactElement => {
    const [resourse, setResource] = useState<IResourseResponse | null>(null);
    const [isLoading, setisLoading] = useState<boolean>(false)
    const {id} = useParams();

    useEffect(() => {
        if(id) {
            const getResourse = async () => {
                try {
                    setisLoading(true);
                    const respon = await resourseApi.getProductById(id)
                    setResource(respon.data)
                } catch (error) {
                    if (error instanceof Error) {
                        console.error(error.message)
                    }
                }
                setisLoading(false);
            }
            getResourse()
        }
    }, [id])

    return (
        <Container>
            <Grid container spacing={3} justifyContent='center' m={4}>
                {isLoading ? (
                    <CircularProgress/>                    
                ) : (
                    <Box sx={{ maxWidth: 250}}>
                        <Card sx={{bgcolor:`${resourse?.color}`}}>
                            <CardContent>
                                <Typography noWrap gutterBottom variant="h6" component='div'>
                                    {resourse?.name}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    {resourse?.pantone_value} {resourse?.year}
                                </Typography>
                            </CardContent>
                        </Card>
                    </Box>
                    )
                }
            </Grid>
        </Container>
    );
}

export default Resource;