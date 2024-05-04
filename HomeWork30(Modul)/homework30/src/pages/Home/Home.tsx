import {ReactElement, FC, useState} from "react";
import {Box, CircularProgress, Container, Grid, Pagination, Tab} from '@mui/material'
import UserCard from "./User/UserCard";
import HomeStore from "./HomeStore";
import {observer} from "mobx-react-lite";
import { TabContext, TabList, TabPanel } from "@mui/lab";
import FormUpdateUser from "./Update/FormUpdateUser";
import FormaCreateUser from "./Create/FormaCreateUser";

const store = new HomeStore();

const Home: FC<any> = (): ReactElement => {
    const [value, setValue] = useState('1');

  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    setValue(newValue);
  };
    
    return (  
<Container>
<Box sx={{ width: '100%', typography: 'body1' }}>
<TabContext value={value}>
  <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
    <TabList onChange={handleChange} aria-label="lab API tabs example">
      <Tab label="User" value="1" />
      <Tab label="Create User" value="2" />
      <Tab label="Update User" value="3" />  
    </TabList>
  </Box>
  <TabPanel value="1">
    <Container>
            <Grid container spacing={3} justifyContent='center' my={4}>
                {store.isLoading ? (
                    <CircularProgress/>
                ): (
                    <>
                    {store.users?.map((item) => (
                        <Grid key={item.id} item lg={2} md={3} xs={6}>
                            <UserCard {...item} />
                        </Grid>
                    ))}
                    </>
                )}
            </Grid>
            <Box 
                sx={{
                    display: 'flex',
                    justifyContent: 'center'
                }}
            >
                <Pagination 
                    count={store.totalPages}
                    page={store.currentPage}
                    onChange={async (event, page) => await store.changePage(page)}
                />    
            </Box>
        </Container>
        </TabPanel>
  <TabPanel value="2"><FormaCreateUser/></TabPanel>
  <TabPanel value="3"><FormUpdateUser/></TabPanel> 
</TabContext>
</Box>
</Container>
    );
};

export default observer(Home);