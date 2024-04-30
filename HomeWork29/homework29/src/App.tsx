import TabsNav from "./Navigation/TabsNav"
import * as React from 'react';
import { StyledEngineProvider, CssVarsProvider } from '@mui/joy/styles';

function App() {  
  {
    return (
    <React.StrictMode>
      <StyledEngineProvider injectFirst>
        <TabsNav/>
      </StyledEngineProvider>      
    </React.StrictMode>
    ); 
  }
}

export default App;
