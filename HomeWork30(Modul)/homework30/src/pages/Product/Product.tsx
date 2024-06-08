import {ReactElement, FC} from "react";
import {Box, CircularProgress, Container, Grid, Pagination} from '@mui/material'
import ProductCard from "./ProductCard";
import ProductStore from "./ProductStore";
import {observer} from "mobx-react-lite";

const product = new ProductStore();

const Product: FC<any> = (): ReactElement => {
    return (
        <Container>
            <Grid container spacing={3} justifyContent='center' my={4}>
                {product.isLoading ? (
                    <CircularProgress/>
                ): (
                    <>
                        {product.resourse.map((item) => (
                            <Grid key={item.id} item lg={2} md={3} xs={6}>
                                <ProductCard {...item} />
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
                    count={product.totalPages}
                    page={product.currentPage}
                    onChange={async (event, page) => await product.changePage(page)}
                />    
            </Box>
        </Container>
    );
};

export default observer(Product);