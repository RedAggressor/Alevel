import * as React from 'react';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import {Box} from '@mui/material';
import Users from '../Users/UsersTabs';
import CreateForm from '../TabCreate/OperationUser'
import Typography from '@mui/joy/Typography';
import { FC, ReactElement } from 'react';
interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`vertical-tabpanel-${index}`}
      aria-labelledby={`vertical-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `vertical-tab-${index}`,
    'aria-controls': `vertical-tabpanel-${index}`,
  };
}

 const VerticalTabs: FC<any> = (): ReactElement => {
  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <Box
      sx={{ flexGrow: 1, bgcolor: 'background.paper', display: 'flex', height: '100%' }}
      
    >
      <Tabs
        orientation="vertical"
        variant="scrollable"
        value={value}
        onChange={handleChange}
        aria-label="Vertical tabs example"
        sx={{ borderRight: 1, borderColor: 'divider', height: 300 }}        
      >        
        <Tab label="Users" {...a11yProps(0)} />        
        <Tab label="Create" {...a11yProps(1)} />          
      </Tabs>
      <TabPanel value={value} index={0}>
        <Box sx={{ display: 'flex', height: 224}}  alignItems="center" justifyItems={'center'}>
        </Box>       
      </TabPanel>
      <TabPanel value={value} index={0}>
        <Users/>
      </TabPanel>      
      <TabPanel value={value} index={1}>
      <CreateForm/>
      </TabPanel>       
    </Box>
  );
}

export default VerticalTabs