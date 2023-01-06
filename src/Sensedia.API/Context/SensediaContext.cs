
using Microsoft.EntityFrameworkCore;

namespace Sensedia.API.Context
{
    public class SensediaContext : DbContext
    {
        public SensediaContext(DbContextOptions<SensediaContext> options) : base(options)
        {

        }
    }
}
