import { FC, ReactNode } from "react";
import { Box, CssBaseline } from "@mui/material";
import Navbar from "../Navbar/Navbar";
import Footer from "../Footer/Footer";

interface LayoutProps {
    children: ReactNode;
}

const Layout: FC<LayoutProps> = ({children}) => {
    return (
        <>
            <CssBaseline/>
                <Box
                    sx={{
                        display: 'flex',
                        justifyContent: "flex-start",
                        minHeight: "100vh",
                        maxWidth: "100vw",
                        flexGrow: 1,
                        flexDirection: 'column',                       
                    }}
                >                    
                    <Navbar />          
                    {children}            
                    <Footer />                           
                </Box>
        </>
    );
}

export default Layout;