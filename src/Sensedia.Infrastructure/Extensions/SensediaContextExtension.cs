using Microsoft.EntityFrameworkCore;
using Sensedia.Infrastructure.Context;

namespace Sensedia.Infrastructure.Extensions
{
    public static class SensediaContextExtension
    {
        public static DbSet<T> DbSet<T>(this SensediaContext context) where T : class
        {
            return context.Set<T>();
        }
    }
}
