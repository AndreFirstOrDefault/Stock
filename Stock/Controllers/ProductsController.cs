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

    public ProductsController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
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
        };

        await productRepository.CreateAsync(product);

        // Domain model to DTO
        var response = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Quantity = product.Quantity
        };

        return Ok(response);
    }
}
