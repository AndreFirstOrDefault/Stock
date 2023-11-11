using Stock.Models.Domain;

namespace Stock.Repositories.Interface;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product);

    Task<ICollection<Product>> GetAllAsync();

    Task<Product?> GetById(int id);
}
