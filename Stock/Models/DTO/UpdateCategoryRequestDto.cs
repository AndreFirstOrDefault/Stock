using System.ComponentModel.DataAnnotations;

namespace Stock.Models.DTO;

public class UpdateCategoryRequestDto
{
    [Required]
    public int Id { get; set; }

    [Required] 
    [StringLength(50,MinimumLength = 5)]
    public string? Name { get; set; }

    [Required]
    [StringLength (100,MinimumLength = 10)]
    public string? Description { get; set; }

}
