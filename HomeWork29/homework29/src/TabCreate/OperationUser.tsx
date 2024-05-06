import {Button, Box, Container, TextField, Typography, Card, CardContent, Grid} from '@mui/material';
import {  useState } from 'react';
import { ICreateUser, IUpdateUser } from '../api/responce/user';
import * as apiCreate from '../api/createApi';
import * as apiUpdate from '../api/update';

const CreateForm = () => {
    const [name, setName] = useState('');
    const [job, setJob] = useState('');
    const [respcreate, setRespcreate] = useState<ICreateUser | null>();
    const [respupdate, setRespupdate] = useState<IUpdateUser | null>();
    const [id, setId] = useState(0);
    
      const Create = async () => {
        try{
          const data : ICreateUser = await apiCreate.create({name, job});         
          setRespcreate(data);
          setId(data.id);
        }
        catch (e) {
          if(e instanceof Error){
            alert(e.message);
          }          
        }
      }

      const Update = async () => {
        try{
          const data : IUpdateUser = await apiUpdate.update({name, job}, id.toString());
          setRespupdate(data);          
        } catch (e) {
          if(e instanceof Error){
            alert(e.message);
          }
        }
      }

  return (
   
    <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
      <Grid item xs={3}  >
      <Box
        sx={{
          marginTop: 8,
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',          
        }}        
      >
        <Typography component="h1" variant="h5">
          Create
        </Typography>
        <Box 
          component="form"                    
          onSubmit={async (event) => {
            event.preventDefault();            
            alert('Registartion Seccusfull');
            await Create();                  
          }}
        >
          <TextField
                    type="string"
                    margin="normal"
                    required
                    fullWidth                   
                    label="Name"
                    name="name"
                    onChange={(event) => {setName(event.target.value)}}
                />
                <TextField                    
                    margin="normal"
                    required
                    fullWidth
                    name="job"
                    label="Job"
                    type="string"
                    onChange={(event) => {setJob(event.target.value)}}
                />                
                <Button
                    type="submit"
                    fullWidth
                    sx={{ mt: 3, mb: 2 }}
                    variant="contained"
                >                
                 Submit                   
                </Button>                
            </Box>
            </Box> 
          </Grid>
          <Grid item xs={3}>
            <Box sx={{ minWidth: 275}}>
        <Card >
          <CardContent >
            <Typography sx={{ mb: 1.5 }} color="text.secondary">
            id: {respcreate?.id}  
            </Typography>
            <Typography variant="h5" component="div">
            name: {respcreate?.name}
            </Typography>
            <Typography variant="h5" component="div">
            job:{respcreate?.job}
            </Typography>
            <Typography variant="body2">
            createdAt: {respcreate?.createdAt}              
            </Typography>
          </CardContent>
        </Card>
      </Box>
      </Grid>
      <Grid item xs={3}  >
      <Box
        sx={{
          marginTop: 8,
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',          
        }}        
      >
        <Typography component="h1" variant="h5">
          Update
        </Typography>
        <Box 
          component="form"                    
          onSubmit={async (event) => {
            event.preventDefault();            
            alert('update Seccusfull');
            await Update();                  
          }}
        >         
                  <TextField
                    type="string"
                    margin="normal"
                    required
                    fullWidth                   
                    name="id"
                    value={id.toString()}
                    disabled
                />
                <TextField
                    type="string"
                    margin="normal"
                    required
                    fullWidth                   
                    label="Name"
                    name="name"
                    onChange={(event) => {setName(event.target.value)}}
                />
                <TextField                    
                    margin="normal"
                    required
                    fullWidth
                    name="job"
                    label="Job"
                    type="string"
                    onChange={(event) => {setJob(event.target.value)}}
                />                
                <Button
                    type="submit"
                    fullWidth
                    sx={{ mt: 3, mb: 2 }}
                    variant="contained"
                >                
                 Submit                   
                </Button>                
            </Box>
            </Box>          
          </Grid>
          <Grid item xs={3}>
            <Box sx={{ minWidth: 275}}>
        <Card > 
          <CardContent >                  
            <Typography variant="h5" component="div">
            name: {respupdate?.name}
            </Typography>
            <Typography variant="h5" component="div">
            job:{respupdate?.job}
            </Typography>
            <Typography variant="body2">
            updatedAt: {respupdate?.updatedAt}              
            </Typography>
          </CardContent>
        </Card>
      </Box>
      </Grid>
      </Grid>
      
     
      
    
  );
}

export default CreateForm;