﻿using Microsoft.AspNetCore.Mvc;
using Sensedia.Core.Entities;
using Sensedia.Infrastructure.Context;

namespace Sensedia.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly SensediaContext _sensediaContext;

        public TestsController(SensediaContext sensediaContext)
        {
            _sensediaContext = sensediaContext;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetTests()
        {
            return _sensediaContext.Products.ToList();
        }
    }
}
