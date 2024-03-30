﻿using HomeWork22.Datas;
using HomeWork22.Datas.Entities;
using HomeWork22.DbWrappers.Abstracts;
using HomeWork22.Dtos;
using HomeWork22.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeWork22.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ApplicatDbContext _dbContext;

        public ProductRepository(IDbContextWrapper<ApplicatDbContext> dbContextWrapper)
        { 
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddProductAsync(string name, double price)
        {
            var product = new ProductEntity()
            {
                Name = name,
                Price = price
            };

            var products = await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return products.Entity.Id;
        }

        public async Task<ProductEntity> UpdataProductAsync(int id, string name, double price)
        {
            var product = await GetProductAsync(id);

            product!.Price = price == 0 ? product.Price : price;
            product.Name = name is null ? product.Name : name;

            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductAsync(id);

            _dbContext.Products.Remove(product!);
            _dbContext.SaveChanges();
        }

        public async Task<ProductEntity?> GetProductAsync(int id)
        {
            return await _dbContext.Products
                .FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductListAsync(RequestPage request)
        {
            return await _dbContext.Products
               .Where(x => x.Price >= request.PriceMin && x.Price <= request.PriceMax)
               .Where(x => x.Name == request.Name)
               .Skip(request.PageSize * (request.PageNamber - 1))
               .Take(request.PageSize)
               .OrderDescending()
               .ToListAsync();
        }
    }
}
