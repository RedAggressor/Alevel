using HomeWork23.Dto.Requests;
using HomeWork23.Dto;
using HomeWork23.Models;

namespace HomeWork23.Services.Abstracts
{
    internal interface IPetService
    {
        public Task<int> AddPetAsync(Pet pet);
        public Task<Pet> GetPetAsync(int id);
        public Task<string> DeletePetAsync(int id);
        public Task<Pet> UpdateAsync(Pet pet);
        public Task<Responses<string, int>> GetPetPageAsync(PetRequest request);
    }
}
