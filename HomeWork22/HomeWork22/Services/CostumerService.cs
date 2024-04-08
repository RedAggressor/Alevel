using HomeWork22.Datas;
using HomeWork22.DbWrappers.Abstracts;
using HomeWork22.Models;
using HomeWork22.Repositories.Abstractions;
using HomeWork22.Services.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork22.Services
{
    internal class CostumerService : BaseDataService<ApplicatDbContext>, ICostumerService
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly ILogger<CostumerService> _logger;

        public CostumerService(
            ICostumerRepository costumerRepository,
            ILogger<CostumerService> loggerService,
            IDbContextWrapper<ApplicatDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicatDbContext>> logger)
            : base
            (dbContextWrapper, logger)
        {
            _costumerRepository = costumerRepository;
            _logger = loggerService;
        }

        public async Task<int> AddCostumerAsync(string lastname, string firstname)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _costumerRepository.AddCostumerAsync(lastname, firstname);

                _logger.LogInformation($"Succesfull create costumer with id: {id}");

                return id;
            });
        }

        public async Task<Costumer> UpdateCostumerAsync(int id, string lastname = null!, string firstname = null!)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var costumers = await _costumerRepository.UpdateCostumerAsync(id, lastname);

                return new Costumer()
                {
                    Id = costumers.Id,
                    Lastname = costumers.LastName,
                    Firstname = costumers.FirstName,
                    Fullname = $"{costumers.LastName} {costumers.FirstName}"
                };
            });
        }

        public async Task<string> DeleteCostumerAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var status = await _costumerRepository.DeleteCostumerAsync(id);

                return status;
            });
        }

        public async Task<Costumer> GetCostumerAsync(int id)
        {
            var costumerEntity = await _costumerRepository.GetCostumerAsync(id);

            if (costumerEntity is null)
            {
                _logger.LogWarning($"Costumer is not founded with id: {id}");

                return null!;
            }

            return new Costumer()
            {
                Id = costumerEntity.Id,
                Firstname = costumerEntity.FirstName,
                Lastname = costumerEntity.LastName,
                Fullname = $"{costumerEntity.LastName} {costumerEntity.FirstName} ",
            };
        }
    }
}
