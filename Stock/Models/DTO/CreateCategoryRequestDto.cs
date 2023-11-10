using System.ComponentModel.DataAnnotations;

namespace Stock.Models.DTO;

public class CreateCategoryRequestDto
{
    [StringLength(50, MinimumLength = 5, ErrorMessage = "O nome precisa ter entre 5 e 50 caracteres.")]
    public string? Name { get; set; }

    [StringLength(100, MinimumLength = 10, ErrorMessage = "A descrição precisa ter entre 10 e 100 caracteres.")]
    public string? Description { get; set; }
}
