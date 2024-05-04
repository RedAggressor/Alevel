import {Card, CardActionArea, CardContent, CardMedia, Typography} from "@mui/material"
import {FC, ReactElement} from "react";
import {IUserResponse} from "../../../api/response/userResponse";
import {useNavigate} from "react-router-dom";

const UserCard: FC<IUserResponse> = (props) : ReactElement => {
    const navigate = useNavigate()

    return (
        <Card sx={{maxWidth: 250}}>
            <CardActionArea onClick={()=> navigate(`/user/${props.id}`)}>
                <CardMedia
                    component='img'
                    height='250'
                    image={props.avatar}
                    alt={props.first_name}
                />
                <CardContent>
                    <Typography noWrap gutterBottom variant="h6" component='div'>
                        {props.first_name} {props.last_name}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        {props.email}
                    </Typography>
                </CardContent>
            </CardActionArea>
        </Card>
    );
}

export default UserCard;