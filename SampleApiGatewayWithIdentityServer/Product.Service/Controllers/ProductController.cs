using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Product.Service.Models;

namespace Product.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private static readonly string[] ProductNames = new[]
        {
            "Apple", "Dell", "Acer", "Amazon", "Sumsung"
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ProductModel
            {
                Date = DateTime.Now.AddDays(index),
                Price = rng.Next(1000, 2000),
                Inventory = rng.Next(0, 100),
                Name = ProductNames[index - 1]
            })
            .ToArray();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return $"This is product {id}.";
        }
    }
}
