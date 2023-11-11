using System.ComponentModel.DataAnnotations;

namespace Stock.Models.DTO;

// 1º

public class CreateCategoryRequestDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
