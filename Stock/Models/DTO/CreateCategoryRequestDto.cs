using System.ComponentModel.DataAnnotations;

namespace Stock.Models.DTO;

// 1º

public class CreateCategoryRequestDto
{
    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string? Name { get; set; }

    [Required]
    [StringLength (100, MinimumLength = 10)]
    public string? Description { get; set; }
}
