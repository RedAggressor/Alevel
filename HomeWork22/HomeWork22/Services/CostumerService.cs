using HomeWork22.Models;
using HomeWork22.Repositories.Abstractions;
using HomeWork22.Services.Abstracts;
using Microsoft.Extensions.Logging;

namespace HomeWork22.Services
{
    internal class CostumerService : ICostumerService
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly ILogger<CostumerService> _logger;

        public CostumerService(ICostumerRepository costumerRepository, ILogger<CostumerService> logger)
        { 
            _costumerRepository = costumerRepository;
            _logger = logger;
        }

        public async Task<int> AddCostumerAsync(string lastname, string firstname)
        {
            var id = await _costumerRepository.AddCostumer(lastname, firstname);

            _logger.LogInformation($"Succesfull create costumer with id: {id}");
            
            return id;
        }

        public async Task<Costumer> GetCostumerAsync(int id)
        {
            var costumerEntity = await _costumerRepository.GetCostumer(id);

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
                Fullname = $"{costumerEntity.FirstName} {costumerEntity.LastName}",
            };
        }
    }
}
