
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Sensedia.API.Entities;

namespace Sensedia.API.Context
{
    public class SensediaContext : DbContext
    {       

        public DbSet<Product> Products { get; set; }
        public SensediaContext(DbContextOptions<SensediaContext> options) : base(options)
        {
            
        }
    }
}
