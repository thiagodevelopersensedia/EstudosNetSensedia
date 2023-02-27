using Microsoft.AspNetCore.Mvc;
using Sensedia.Core.Entities;
using Sensedia.Core.Interfaces.Generic;
using Sensedia.Core.Interfaces.Products;

namespace Sensedia.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _productGeneric;

        public ProductsController(IProductRepository productRepository, IGenericRepository<Product> productGeneric)
        {
            _productRepository = productRepository;
            _productGeneric = productGeneric;
        }

        [HttpGet("get-all")]
        public async  Task<ActionResult<List<Product>>> GetProducts()
        {
            var products =  await _productGeneric.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{productId}/get-details")]
        public async Task<ActionResult<Product>> GetProductsDetails(int productId)
        {
            var products = await _productGeneric.GetByIdAsync(productId);

            return Ok(products);
        }
    }
}