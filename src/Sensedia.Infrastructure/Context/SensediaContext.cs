
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Sensedia.Infrastructure.Context
{
    public class SensediaContext : DbContext
    {
        public SensediaContext(DbContextOptions<SensediaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
