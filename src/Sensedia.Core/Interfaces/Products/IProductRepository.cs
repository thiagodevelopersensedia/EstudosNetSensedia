using Sensedia.Core.Entities;

namespace Sensedia.Core.Interfaces.Products
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();

    }
}
