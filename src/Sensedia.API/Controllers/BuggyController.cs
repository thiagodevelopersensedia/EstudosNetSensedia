using Microsoft.AspNetCore.Mvc;
using Sensedia.API.Error;
using Sensedia.Core.Entities;
using Sensedia.Infrastructure.Context;
using Sensedia.Infrastructure.Extensions;

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
            var thing = _context.DbSet<Product>().Find(9485);

            if (thing == null) { return NotFound(new ApiResponse(404)); }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
           var thing = _context.DbSet<Product>().Find(13245);
           var returnThing = thing.Description;

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok(new ApiResponse(400));
        }
    }
}
