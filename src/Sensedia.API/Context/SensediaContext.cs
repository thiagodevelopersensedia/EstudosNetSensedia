
using Microsoft.EntityFrameworkCore;

namespace Sensedia.API.Context
{
    public class SensediaContext : DbContext
    {
        public SensediaContext(DbContextOptionsBuilder<SensediaContext> options)
        {

        }
    }
}
