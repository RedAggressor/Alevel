using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeWork23.Wrapper.Abstracts
{
    internal abstract class BaseDataService<T> : IBaseDataService
        where T : DbContext
    {
        private readonly IDbContextWrapper<T> _dbContextWrapper;
        private readonly ILogger<IBaseDataService> _logger;

        public BaseDataService(
            IDbContextWrapper<T> dbContextWrapper,
            ILogger<IBaseDataService> logger)
        { 
            _dbContextWrapper = dbContextWrapper;
            _logger = logger;
        }

        protected Task ExecuteSafeAsync(
            Func<Task> func,
            CancellationToken cancellationToken = default) => 
                ExecuteSafeAsync(token => func(), cancellationToken);

        protected Task<TResult> ExecuteSafeAsync<TResult>(
            Func<Task<TResult>> func,
            CancellationToken cancellationToken = default) =>
                ExecuteSafeAsync(token => func(), cancellationToken);

        private async Task ExecuteSafeAsync(
            Func<CancellationToken, Task> func,
            CancellationToken cancellationToken = default)
        { 
            await using var transaction = await _dbContextWrapper.BeginTransactionAsync(cancellationToken);

            try
            {
                await func(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                _logger.LogError(ex, $"transaction is rollbacked");
                throw;
            }
        }

        private async Task<TResult> ExecuteSafeAsync<TResult>(
            Func<CancellationToken, Task<TResult>> func,
            CancellationToken cancellationToken = default)
        {
            await using var transaction = await _dbContextWrapper.BeginTransactionAsync(cancellationToken);

            try 
            {
                var result = await func(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return result;
            }
            catch (Exception ex) 
            {
                await transaction.RollbackAsync(cancellationToken);
                _logger.LogError(ex, $"transaction is rollbacked");
                throw;
            }
        }
    }   
}
