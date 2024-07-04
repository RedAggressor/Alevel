import { Box, Container, IconButton, Link, Menu, MenuItem, Toolbar, Typography } from "@mui/material";
import { FC, ReactElement, useState } from "react";
import { routes } from "../../routes";
import { NavLink } from "react-router-dom";
import MenuIcon from "@mui/icons-material/Menu";

const Navbar: FC = (): ReactElement => {
    const [anchorElNav, setAnchorElNav] = useState(null);
  
    const handleOpenNavMenu = (event: any) => {
      setAnchorElNav(event.currentTarget);
    };
  
    const handleCloseNavMenu = () => {
      setAnchorElNav(null);
    };
  
    return (
      <Box
        sx={{
          width: "100%",
          height: "auto",
          backgroundColor: "secondary.main",
        }}
      >
        <Container maxWidth="xl">
          <Toolbar disableGutters>            
            <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
              <IconButton
                size="large"
                aria-label="account of current user"
                aria-controls="menu-appbar"
                aria-haspopup="true"
                onClick={handleOpenNavMenu}
                color="inherit"
              >
                <MenuIcon />
              </IconButton>
              <Menu
                id="menu-appbar"
                anchorEl={anchorElNav}
                anchorOrigin={{
                  vertical: "bottom",
                  horizontal: "left",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "left",
                }}
                open={Boolean(anchorElNav)}
                onClose={handleCloseNavMenu}
                sx={{
                  display: { xs: "block", md: "none" },
                }}
              >
                {routes.map((page) => (
                !!page.enabled && <Link
                    key={page.key}
                    component={NavLink}
                    to={page.path}
                    color="black"
                    underline="none"
                    variant="button"
                  >
                    <MenuItem onClick={handleCloseNavMenu}>
                      <Typography textAlign="center">{page.title}</Typography>
                    </MenuItem>
                  </Link>
                ))}
              </Menu>
            </Box>            
            <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
              <Box
                sx={{
                  display: "flex",
                  flexDirection: "row",
                  justifyContent: "flex-start",
                  alignItems: "center",
                  marginLeft: "1rem",
                }}
              >
                {routes.map((page) => (
                 !!page.enabled && <Link
                    key={page.key}
                    component={NavLink}
                    to={page.path}
                    color="black"
                    underline="none"
                    variant="button"
                    sx={{ fontSize: "large", marginLeft: "2rem" }}
                  >
                    {page.title}
                  </Link>
                ))}
              </Box>
            </Box>
          </Toolbar>
        </Container>
      </Box>
    );
  };
  
  export default Navbar;