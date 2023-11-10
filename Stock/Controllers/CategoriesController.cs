using Microsoft.AspNetCore.Mvc;
using Stock.Data;
using Stock.Models.Domain;
using Stock.Models.DTO;
using Stock.Repositories.Interface;

namespace Stock.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;
    private readonly ICategoryRepository categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
    {
        // Map DTO to Domain Model
        var category = new Category
        {
            Name = request.Name,
            Description = request.Description
        };

        await categoryRepository.CreateAsync(category);

        // Domain model to DTO
        var response = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

        return Ok(response);
    }
}
