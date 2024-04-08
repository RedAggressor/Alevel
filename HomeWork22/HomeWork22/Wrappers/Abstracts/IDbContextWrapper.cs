using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeWork22.DbWrappers.Abstracts
{
    internal interface IDbContextWrapper<T> where T : DbContext
    {
        public T DbContext { get; }

        public Task<IDbContextTransaction> BeginTrasactionAsync(CancellationToken cancellationToken);
    }
}
