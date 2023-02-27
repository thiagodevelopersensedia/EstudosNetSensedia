using Microsoft.EntityFrameworkCore;
using Sensedia.Core.Entities;
using Sensedia.Core.Interfaces.Products;
using Sensedia.Infrastructure.Context;
using Sensedia.Infrastructure.Extensions;

namespace Sensedia.Infrastructure.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly SensediaContext _sensediaContext;

        public ProductRepository(SensediaContext sensediaContext)
        {
           _sensediaContext = sensediaContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _sensediaContext.DbSet<Product>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _sensediaContext.DbSet<Product>()
                .ToListAsync();
        }
    }
}
