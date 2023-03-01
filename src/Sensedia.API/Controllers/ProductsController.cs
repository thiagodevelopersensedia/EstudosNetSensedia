using Microsoft.AspNetCore.Mvc;
using Sensedia.Core.DTO;
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
        public async  Task<ActionResult<List<ProductToReturnDTO>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var productList = await _productsRepo.GetListEntityAsync(spec);

            return Ok(productList.Select(x => new ProductToReturnDTO {
                Id = x.Id,
                ProducDescription = x.Description,
                ProductName = x.Name,
                PictureUrl = x.PictureUrl,
                ProductPrice = x.Price,
                ProductBrand = x.ProductBrand.Name,
                ProductType = x.ProductType.Name
            }));
        }

        [HttpGet("get-product")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productId);

            var product = await _productsRepo.GetEntityWithSpecAsync(spec);

            return Ok(new ProductToReturnDTO
            {
                Id = product.Id,
                ProducDescription = product.Description,
                ProductName = product.Name,
                PictureUrl = product.PictureUrl,
                ProductPrice = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            });
        }

        [HttpGet("get-details")]
        public async Task<ActionResult<Product>> GetProductsDetails([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);

            var product = await _productsRepo.GetEntityWithSpecAsync(spec);

            return Ok(new ProductToReturnDTO
            {
                Id = product.Id,
                ProducDescription= product.Description,
                ProductName= product.Name,
                PictureUrl = product.PictureUrl,
                ProductPrice= product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            });
        }
    }
}