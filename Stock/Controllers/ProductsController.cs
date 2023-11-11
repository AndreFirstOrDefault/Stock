using Microsoft.AspNetCore.Mvc;
using Stock.Data;
using Stock.Models.Domain;
using Stock.Models.DTO;
using Stock.Repositories.Interface;

namespace Stock.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;
    private readonly IProductRepository productRepository;

    public ProductsController(IProductRepository productRepository, ApplicationDbContext dbContext)
    {
        this.productRepository = productRepository;
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequestDto request)
    {
        // Map DTO to Domain Model
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Quantity = request.Quantity,
            CategoryId = request.CategoryId
            
        };

        await productRepository.CreateAsync(product);

        // Domain model to DTO
        var response = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Quantity = product.Quantity,
            
        };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await productRepository.GetAllAsync();

        // Map Domain model to DTO
        var response = new List<ProductDto>();

        foreach (var product in products)
        {
            response.Add(new ProductDto
            {
                Id= product.Id,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity
            });
        }

        return Ok(response);
        
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var existingProduct = await productRepository.GetById(id);

        // Map Domain model to DTO
        if(existingProduct is null)
        {
            return NotFound("Produto não encontrado");
        }

        return Ok(existingProduct);
    }
}
