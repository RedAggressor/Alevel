using Basket.Host.Models.Responces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
    [Route(ComponentDefaults.DefaultRoute)]
    public class BasketController : ControllerBase
    {
        [HttpPost]        
        public async Task<int> AddUser()
        {
            return 1;
        }

    }
}
