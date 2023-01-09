using Microsoft.AspNetCore.Mvc;
using Sensedia.API.Context;

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
    }
}