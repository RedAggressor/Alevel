import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import {CardActionArea} from '@mui/material';
import { FC, ReactElement } from 'react';

const CardUser: FC<any> = (props): ReactElement =>
{
  return (
  
    <Card sx={{ maxWidth: 250 }}>
      <CardActionArea>
        <CardMedia
          component="img"
          image={props.avatar}
          height='250'          
          alt={props.first_name + props.last_name}
        />
        <CardContent>
          <Typography noWrap gutterBottom variant="h5" component="div">
            {props.first_name} {props.last_name}
          </Typography>
          <Typography noWrap gutterBottom variant="body2" component="div">
          {props.email}
          </Typography>
        </CardContent>
      </CardActionArea>      
    </Card>     
  );
}

export default CardUser;