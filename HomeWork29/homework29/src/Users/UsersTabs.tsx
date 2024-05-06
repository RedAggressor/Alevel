import { Box, Container, Grid, Pagination} from '@mui/material';
import React, { ReactElement, FC, useEffect } from 'react';
import {IUser} from '../api/responce/user';
import {IResponse} from '../api/responce/responce';
import CardUser from './UserCard';
import { getuserByPage } from '../api/useApi';

const Users: FC<any> = (): ReactElement => {
  const [users, setUsers] = React.useState<IUser[]>();
  const [totalPages, setTotalPages] = React.useState<number>(0);
  const [currentPage, setCurrentPage] = React.useState<number>(1);
    
  useEffect(() => {
    const getUsers = async () => {
      try{
        const responsce : IResponse<IUser> = await  getuserByPage(currentPage);       
        setTotalPages(responsce.total_pages);
        setUsers(responsce.data);
      }
      catch (error){
        if (error instanceof Error) {
          alert(error.message)
        }
      }      
    }
    getUsers()
  }, [currentPage]);

  return (
    <Container>
      <Grid container          
        spacing={4}
        justifyContent="center"
        my={4}    
      >
        <>           
        {users?.map((item) => (
          <Grid key={item.id} item md={3} xs={4}>
            <CardUser {...item} />
          </Grid>
        ))} 
        </>              
      </Grid>
        <Box
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