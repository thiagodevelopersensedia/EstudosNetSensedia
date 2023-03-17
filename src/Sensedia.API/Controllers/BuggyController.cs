using Microsoft.AspNetCore.Mvc;
using Sensedia.Infrastructure.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sensedia.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly SensediaContext _context;

        public BuggyController(SensediaContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundResquest()
        {
            return Ok();
        }
    }
}
