using Microsoft.EntityFrameworkCore;
using Stock.Data;
using Stock.Models.Domain;
using Stock.Repositories.Interface;

namespace Stock.Repositories.Implementation;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();

        return product;
    }
    
    public async Task<ICollection<Product>> GetAllAsync()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> DeleteAsync(int id)
    {
        var existingProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        if(existingProduct is null)
        {
            return null;
        }

        dbContext.Remove(existingProduct);
        dbContext.SaveChanges();
        return existingProduct;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        var existingCategory = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

        if(existingCategory is null)
        {
            return null;
        }

        dbContext.Entry(existingCategory).CurrentValues.SetValues(product);
        await dbContext.SaveChangesAsync();

        return product;
    }
}
