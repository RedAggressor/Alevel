using HomeWork23.Datas.Entities;
using HomeWork23.Dto.Requests;
using HomeWork23.Dto;

namespace HomeWork23.Repositories.Abstracts
{
    internal interface IPetRepository
    {
        public Task<int> AddPetAsync(PetEntity pet);
        public Task<PetEntity?> GetPetAsync(int id);
        public Task<string> DeletePetAsync(int id);
        public Task<PetEntity> UpdatePetAsync(PetEntity petEntity);
        public Task<Responses<string, int>> GetPetPageAsync(PetRequest request);
    }
}
