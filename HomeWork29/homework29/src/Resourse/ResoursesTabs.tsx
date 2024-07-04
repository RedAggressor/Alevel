import { Box, Container, Grid, Pagination, Color} from '@mui/material';
import React, { ReactElement, FC, useEffect } from 'react';
import { IResourse } from '../api/responce/resourse';
import { IResponse } from '../api/responce/responce';
import ResourseCard from './ResourseCard';
import * as apiResourse from '../api/resourseApi';

const Resourses: FC<any> = (): ReactElement => {
  const [resours, setResours] = React.useState<IResourse[]>();
  const [totalPages, setTotalPages] = React.useState<number>(0);
  const [currentPage, setCurrentPage] = React.useState<number>(1);
    
  useEffect(() => {
    const getResource = async () => {
      try{
        const responsce : IResponse<IResourse> = await apiResourse.getResouseByPage(currentPage);       
        setTotalPages(responsce.total_pages);
        setResours(responsce.data);
      }
      catch (error){
        if (error instanceof Error) {
          alert(error.message)
        }
      }      
    }
    getResource()
  }, [currentPage]);

  return (
    <Container fixed>
      <Grid container  
        direction="row"
        spacing={3}
        justifyContent="space-evenly"
      >
        {resours?.map((item) => (
          <Grid key={item.id}
            item xs={4}          
            zeroMinWidth
            justifyContent="space-evenly"
            alignItems="center">
            <ResourseCard {...item} />
          </Grid>
        ))}
      </Grid>
      <Box
        mt={5}
        sx={{
          display: 'flex',                 
          justifyContent: 'center',
          
        }}
      >
        <Pagination count={totalPages} page={currentPage} onChange={ (event, page)=> setCurrentPage(page)} />
      </Box>      
    </Container>
  );  
}

export default Resourses;