using HomeWork22.DbWrappers.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeWork22.DbWrappers
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

        public Task<IDbContextTransaction> BeginTrasactionAsync(CancellationToken cancellationToken)
        { 
            return _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
