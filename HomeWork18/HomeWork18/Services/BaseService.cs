using HomeWork18.Helpers;
using HomeWork18.Models;

namespace HomeWork18.Services
{
    internal abstract class BaseService
    {
        protected async Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> action)
            where TResult : Validation, new()
        {
            try
            {
                return await action();
            }
            catch (BusinessException ex)
            {
                return new TResult()
                {
                    Error = ex.Message,
                    ErrorCode = ex.ErrorCode,
                };
            }
        }
    }
}
