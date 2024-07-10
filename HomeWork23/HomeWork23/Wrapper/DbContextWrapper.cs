using HomeWork23.Wrapper.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeWork23.Wrapper
{
    internal class DbContextWrapper<T> : IDbContextWrapper<T>
        where T : DbContext
    {
        private readonly T _dbContext;
        public DbContextWrapper(IDbContextFactory<T> dbContextFactory) 
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public T DbContext => _dbContext;

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken) 
        {
            return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
