using Stock.Models.Domain;

namespace Stock.Repositories.Interface;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
}
