using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sensedia.API.Context;
using Sensedia.API.Entities;


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