import * as React from 'react';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import {Box} from '@mui/material';
import Users from '../Users/UsersTabs';
import OutlinedCard from '../Resourse/ResoursesTabs';
import RegistrationForm from '../TabRegistration/RegistrationForm'
import Typography from '@mui/joy/Typography';
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

export default function VerticalTabs() {
  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <Box
      sx={{ flexGrow: 1, bgcolor: 'background.paper', display: 'flex', height: 224 }}
      
    >
      <Tabs
        orientation="vertical"
        variant="scrollable"
        value={value}
        onChange={handleChange}
        aria-label="Vertical tabs example"
        sx={{ borderRight: 1, borderColor: 'divider', height: 300 }}        
      >
        <Tab label="Home" {...a11yProps(0)} />
        <Tab label="Users" {...a11yProps(1)} />
        <Tab label="Resourse" {...a11yProps(2)} />
        <Tab label="Registration" {...a11yProps(3)} />     
      </Tabs>
      <TabPanel value={value} index={0}>
        <Box sx={{ flexGrow: 1, display: 'flex', height: 224}}  alignItems="center" justifyItems={'center'}>
        <Typography level="h1">
          Home  
        </Typography>
        </Box>       
      </TabPanel>
      <TabPanel value={value} index={1}>
        <Users/>
      </TabPanel>
      <TabPanel value={value} index={2}>
        <OutlinedCard/>        
      </TabPanel>
      <TabPanel value={value} index={3}>
      <RegistrationForm/>
      </TabPanel>    
    </Box>
  );
}