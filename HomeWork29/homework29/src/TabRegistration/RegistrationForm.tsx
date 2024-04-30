import * as React from 'react';
import Button from '@mui/joy/Button';
import Input from '@mui/joy/Input';
import Stack from '@mui/joy/Stack';
import FormLabel from '@mui/joy/FormLabel';
import { Box} from '@mui/material';

export default function RegistrationForm() {
  return (
    <Box >      
  <form action='https://reqres.in/api/users' method='post'
    onSubmit={(event) => {      
      const formData = new FormData(event.currentTarget);
      const formJson = Object.fromEntries((formData as any).entries());
      alert('Registartion Seccusfull');
      alert(JSON.stringify(formJson));   
    }}
    >
    <Stack spacing={1} width={300}>
      <FormLabel>lastname</FormLabel>
      <Input type='text' name='lastname' placeholder="lastname" required />
      <FormLabel>firstname</FormLabel>
      <Input type='text' name='firstname' placeholder="firstname" required />
      <FormLabel>mail</FormLabel>
      <Input type="email" name='mail' placeholder="mail" required />
      <FormLabel>password</FormLabel>
      <Input type='password' name='mail' placeholder="password" required />
      <Button type="submit">Submit</Button>
    </Stack>
  </form> 
  </Box>  
  );
}