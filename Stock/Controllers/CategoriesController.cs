using Microsoft.AspNetCore.Mvc;
using Stock.Data;
using Stock.Models.Domain;
using Stock.Models.DTO;
using Stock.Repositories.Interface;

namespace Stock.Controllers;

// 2º - 4º - 6º

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

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await categoryRepository.GetAllAsync();

        // Map Domain model to DTO
        var response = new List<CategoryDto>();
        foreach (var category in categories)
        {
            response.Add(new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            });
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var existingCategory = await categoryRepository.GetById(id);

        if(existingCategory == null)
        {
            return NotFound();
        }

        return Ok(existingCategory);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        var existingCategory = await categoryRepository.DeleteAsync(id);

        if(existingCategory  is null)
        {
            return NotFound("Categoria não encontrada");
        }

        // Convert Domain model to DTO
        var response = new CategoryDto 
        {
            Id = existingCategory.Id,
            Name = existingCategory.Name,
            Description = existingCategory.Description
        };

        return Ok(response);
    }

}
