using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sensedia.API.Helpers;
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
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository,
            IGenericRepository<Product> productsRepo, IMapper mapper)
        {
            _productRepository = productRepository;
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async  Task<ActionResult<List<ProductToReturnDTO>>> GetProducts()
        {
            var cpf = "12378";
            var result = cpf.FormatarCPF();

            var spec = new ProductsWithTypesAndBrandsSpecification();

            var productList = await _productsRepo.GetListEntityAsync(spec);

            var productDTOList = _mapper.Map<List<ProductToReturnDTO>>(productList);
            return Ok(productDTOList);
        }

        [HttpGet("get-product")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productId);

            var product = await _productsRepo.GetEntityWithSpecAsync(spec);


            var productDTO = _mapper.Map<ProductToReturnDTO>(product);
            return Ok(productDTO);
        }


    }
}