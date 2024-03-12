using HomeWork18.Models;

namespace HomeWork18.Services.Abstracts
{
    internal interface IAuthenticationService
    {
        public Task<Register> RegisterAsync(string? email, string? password);
        public Task<Login> LoginAsync(string? email, string? password);
    }
}
