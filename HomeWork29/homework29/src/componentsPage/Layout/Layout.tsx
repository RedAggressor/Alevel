import { Box, CssBaseline } from "@mui/material";
import { FC, ReactNode } from "react";
import Footer from "../Footer/Footer";
import Navbar from "../Navbar/Navbar";


interface LayoutProps {
    children: ReactNode;
}

const Layout: FC<LayoutProps> = ({children}) => {
    return (
        <>
            <CssBaseline/>
            <Box
                sx={{
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "flex-start",
                    minHeight: "100vh",
                    maxWidth: "100vw",
                    flexGrow: 1,
                }}
            >
                <Navbar/>
                {children}
                <Footer/>
            </Box>
        </>
    );
}

export default Layout;