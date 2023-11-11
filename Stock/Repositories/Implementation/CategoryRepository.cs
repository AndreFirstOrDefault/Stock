using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Stock.Data;
using Stock.Models.Domain;
using Stock.Repositories.Interface;

namespace Stock.Repositories.Implementation;

// 3º

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();

        return category;
    }

    public async Task<ICollection<Category>> GetAllAsync()
    {
        return await dbContext.Categories.ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        var existingCategory =  await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if(existingCategory != null)
        {
            return existingCategory;
        }
        throw new Exception("Categoria não encontrada");
        
    }

    public async Task<Category> DeleteAsync(int id)
    {
        var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if( existingCategory is null)
        {
            return null;
        }

        dbContext.Categories.Remove(existingCategory);
        await dbContext.SaveChangesAsync();
        return existingCategory;

    }

    public async Task<Category> UpdateAsync(Category category)
    {
        var existingCategory = dbContext.Categories.FirstOrDefault(c => c.Id == category.Id);

        if(existingCategory != null)
        {
            dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
            await dbContext.SaveChangesAsync();

            //existingCategory.Id = category.Id;
            //existingCategory.Name = category.Name;
            //existingCategory.Description = category.Description;
            //await dbContext.SaveChangesAsync();

            return category;
        }

        return null;
    }

    
}
