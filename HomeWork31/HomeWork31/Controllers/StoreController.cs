using HomeWork31.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork31.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private Item[] Summaries =
        {
            new Item()
            {
                Name = "Aplle",
                Price = 20
            },
            new Item()
            {
                Name = "Banana",
                Price = 50
            },
            new Item()
            {
                Name = "Orange",
                Price = 60
            },
            new Item()
            {
                Name = "Mango",
                Price = 45,
            },
            new Item()
            {
                Name = "Coconuts",
                Price = 20
            }
        };

        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetListFruits")]
        public IEnumerable<Item> Get()
        {
            return Summaries;
        }

        [HttpPost("AddItem")]
        public string Post(Item input)
        {
            var result = new Item[Summaries.Length];

            for (int i = 0; i < Summaries.Length; i++)
            {
                result[i] = Summaries[i];
            }

            result[^1] = input;
            Summaries = result;

            return $"item seccusfull add, id item = {result.Length}";
        }
    }
}
