import { createTheme  } from '@mui/material/styles';
import Layout from "./componentsPage/Layout/Layout";
import { CssBaseline,ThemeProvider} from "@mui/material";
import { routes } from './routes';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

function App() { 
    const theme = createTheme({
      palette: {
        primary: {
          light: "#63b8ff",
          main: "#0989e3",
          dark: "#005db0",
          contrastText: "#000",
        },
        secondary: {
          main: "#4db6ac",
          light: "#82e9de",
          dark: "#00867d",
          contrastText: "#000",
        },
      },
    });

    return (
    <ThemeProvider theme={theme}>
      <CssBaseline/>
      <Router>
        <Layout>
          <Routes>
            {routes.map((route) => (
              <Route 
                key={route.key}
                path={route.path}
                element={<route.component />}
                />
            ))}
          </Routes>
        </Layout>
      </Router>
    </ThemeProvider>
        
      
    );   
}

export default App;
