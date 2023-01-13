
using Microsoft.EntityFrameworkCore;
using Sensedia.Core.Entities;

namespace Sensedia.Infrastructure.Context
{
    public class SensediaContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public SensediaContext(DbContextOptions<SensediaContext> options) : base(options)
        {

        }
    }
}
