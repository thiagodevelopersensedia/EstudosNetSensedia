using Microsoft.AspNetCore.Mvc;
using Sensedia.Core.Entities;
using Sensedia.Infrastructure.Context;

namespace Sensedia.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly SensediaContext _sensediaContext;

        public ProductsController(SensediaContext sensediaContext)
        {
            _sensediaContext = sensediaContext;
        }

        [HttpGet()]
        public ActionResult<List<Product>> GetProducts()
        {
            return _sensediaContext.Products.ToList();
        }
    }
}