using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogBrandRepository> _logger;

        public CatalogBrandRepository(IDbContextWrapper<ApplicationDbContext> contextWrapper, ILogger<CatalogBrandRepository> logger)
        {
            _dbContext = contextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<CatalogBrand?> GetById(int? id)
        {
            CatalogBrand? responce;

            try
            {
                responce = await _dbContext.CatalogBrands
                .FirstOrDefaultAsync(f => f.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                throw new BusinessException(ex.Message);
            }

            return responce!;
        }

        public async Task<ICollection<CatalogBrand>> GetList()
        {
            return await _dbContext.CatalogBrands.ToListAsync();
        }

        public async Task<int?> AddAsync(string? brand)
        {
            if (brand is null)
            {
                _logger.LogWarning("brand null!");
                throw new BusinessException("brand null!");
            }

            var entity = await _dbContext.CatalogBrands
                .AddAsync(new CatalogBrand()
                {
                    Brand = brand
                });

            await _dbContext.SaveChangesAsync();

            return entity.Entity.Id;
        }

        public async Task<string> DeleteAsync(int? id)
        {
            var entity = await GetById(id);

            var message = _dbContext.CatalogBrands.Remove(entity!);
            await _dbContext.SaveChangesAsync();

            return message.State.ToString();
        }

        public async Task<CatalogBrand?> UpdateAsync(CatalogBrand? catalogBrand)
        {
            if (catalogBrand is null)
            {
                _logger.LogWarning("entity is null");
                throw new BusinessException("brand null!");
            }

            var entity = await GetById(catalogBrand.Id);
            entity!.Brand = catalogBrand.Brand;

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
