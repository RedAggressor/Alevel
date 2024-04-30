import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { Button, CardActionArea, CardActions, Box} from '@mui/material';

export default function CardUser(props:any)
{
  return (
  <Box> 
    <Card>
      <CardActionArea>
        <CardMedia
          component="img"
          image={props.avatar}
          height='250'
          width='100'
          alt={props.first_name + props.last_name}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            {props.first_name} {props.last_name}
          </Typography>
          <Typography variant="body2" color="text.secondary">
          {props.email}
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardActions>
        <Button size="small" color="primary">
          See profile
        </Button>
      </CardActions>
    </Card> 
    </Box>
  );
}