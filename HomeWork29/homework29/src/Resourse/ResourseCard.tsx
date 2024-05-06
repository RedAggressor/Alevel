import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import { Box} from '@mui/material';
import { FC, ReactElement } from 'react';

const ResourseCard: FC<any> = (props):ReactElement =>  {
    return (
      <Box sx={{ minWidth: 275}}>
        <Card variant="outlined" sx={{bgcolor:`${props.color}`}}>
          <CardContent >      
            <Typography variant="h5" component="div">
              {props.name}
            </Typography>
            <Typography sx={{ mb: 1.5 }} color="text.secondary">
              {props.year}
            </Typography>
            <Typography variant="body2">
              {props.pantone_value}              
            </Typography>
          </CardContent>
        </Card>
      </Box>
    );
  }

  export default ResourseCard;