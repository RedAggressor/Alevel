using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeWork23.Wrapper.Abstracts
{
    internal interface IDbContextWrapper<T>
        where T : DbContext
    {
        public T DbContext { get; }
        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
