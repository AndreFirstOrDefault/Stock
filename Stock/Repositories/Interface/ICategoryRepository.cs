using Stock.Models.Domain;
using System.Collections.Generic;

namespace Stock.Repositories.Interface;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);

    Task<ICollection<Category>> GetAllAsync();

    Task<Category> GetById(int id);

    Task<Category> DeleteAsync(int id);

    Task<Category> UpdateAsync(Category category);

    //Task<ICollection<Category>> GetByName(string name);

}
