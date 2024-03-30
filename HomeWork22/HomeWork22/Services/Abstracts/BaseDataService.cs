using HomeWork22.DbWrappers.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeWork22.Services.Abstracts
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

        protected Task ExecuteSafeAsync(Func<Task> action, CancellationToken cancellationToken = default) => ExecuteSafeAsync(token => action(), cancellationToken);

        protected Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> action, CancellationToken cancellationToken = default) => ExecuteSafeAsync(token => action(), cancellationToken);

        private async Task ExecuteSafeAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken = default)
        {
            await using var transaction = await _dbContextWrapper.BeginTrasactionAsync(cancellationToken);

            try 
            {
                await action(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex) 
            {
                await transaction.RollbackAsync(cancellationToken);

                _logger.LogError(ex, $"transaction is roll back, some error");

                throw;
            }
        }

        private async Task<TResult> ExecuteSafeAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken = default)
        {
            await using var transaction = await _dbContextWrapper.BeginTrasactionAsync(cancellationToken);

            try
            {
                var result = await action(cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);

                _logger.LogError(ex, $"Failed to execute, transaction is rollback");

                throw;
            }
        }
    }
}
