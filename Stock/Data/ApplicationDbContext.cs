using Microsoft.EntityFrameworkCore;
using Stock.Models.Domain;

namespace Stock.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products{ get; set; }
    public DbSet<Category> Categories { get; set; }
}
