import { Box, Container, Grid, Pagination} from '@mui/material';
import React, { ReactElement, FC, useEffect } from 'react';
import {IUser} from '../interfaces/user';
import {IResponse} from '../interfaces/responce';
import CardUser from './UserCard';

const Users: FC<any> = (): ReactElement => {
  const [users, setUsers] = React.useState<IUser[]>();
  const [totalPages, setTotalPages] = React.useState<number>(0);
  const [currentPage, setCurrentPage] = React.useState<number>(1);
    
  useEffect(() => {
    const fetchData = async () => {
      const data = await fetch(`https://reqres.in/api/users?page=${currentPage}`);
      const responsce : IResponse<IUser> = await data.json();
      setTotalPages(responsce.total_pages);
      setUsers(responsce.data);
    }
    fetchData().catch(console.error);
  });

  return (
    <Container fixed>
      <Grid container  
        direction="row"
        spacing={3}
        justifyContent="space-evenly"
        alignItems="center"            
        columns={{ xs: 2, md: 12 }}
      >               
        {users?.map((item) => (
          <Grid key={item.id} item xs={4} >
            <CardUser {...item} />
          </Grid>
        ))}                
      </Grid>
      <Box
        mt={5}
        sx={{
          display: 'flex',                 
          justifyContent: 'center'
        }}
      >
        <Pagination count={totalPages} page={currentPage} onChange={ (event, page)=> setCurrentPage(page)} />
      </Box>      
    </Container>
  );  
}

export default Users;