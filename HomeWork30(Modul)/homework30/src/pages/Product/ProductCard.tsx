import {Card, CardActionArea, CardContent, Typography, Box} from "@mui/material"
import {FC, ReactElement} from "react";
import { IResourseResponse } from "../../interfaces/productResponce";
import {useNavigate} from "react-router-dom";

const ProductCard: FC<IResourseResponse> = (props): ReactElement => {

    const navigate = useNavigate()
 
     return (
        <Box sx={{maxWidth: 250}}>
            <Card variant="outlined" sx={{ bgcolor:`${props.color}`}} >
                <CardActionArea onClick={() => navigate(`/resourse/${props.id}`)}>
                    <CardContent>
                        <Typography noWrap gutterBottom variant="h6" component="div">
                            {props.name}
                        </Typography>
                        <Typography variant="body2" color="text.secondary">
                            {props.year} {props.pantone_value}
                        </Typography>
                    </CardContent>
                </CardActionArea>
            </Card>
        </Box>
    )
}

export default ProductCard;