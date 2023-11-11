using Stock.Models.Domain;

namespace Stock.Repositories.Interface;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);

    Task<ICollection<Category>> GetAllAsync();

    Task<Category> GetById(int id);

    Task<Category> DeleteAsync(int id);

}
