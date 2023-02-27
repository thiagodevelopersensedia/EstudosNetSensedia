using Microsoft.AspNetCore.Mvc;
using Sensedia.Core.Entities;
using Sensedia.Core.Entities.Specifications.Params.Products;
using Sensedia.Core.Entities.Specifications.Products;
using Sensedia.Core.Interfaces.Generic;
using Sensedia.Core.Interfaces.Products;

namespace Sensedia.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _productsRepo;

        public ProductsController(IProductRepository productRepository, IGenericRepository<Product> productsRepo)
        {
            _productRepository = productRepository;
            _productsRepo = productsRepo;
        }

        [HttpGet("get-all")]
        public async  Task<ActionResult<List<Product>>> GetProducts()
        {
            var products =  await _productsRepo.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("get-details")]
        public async Task<ActionResult<Product>> GetProductsDetails([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);

            var product = await _productsRepo.GetEntityWithSpecAsync(spec);

            return Ok(product);
        }
    }
}