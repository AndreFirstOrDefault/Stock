using Stock.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Stock.Models.DTO;

public class CreateProductRequestDto
{
    [StringLength(50, MinimumLength = 5, ErrorMessage = "O nome precisa ter entre 5 e 50 caracteres.")]
    public string? Name { get; set; }

    [StringLength(100, MinimumLength = 10, ErrorMessage = "A descrição precisa ter entre 10 e 100 caracteres.")]
    public string? Description { get; set; }

    [Range(0, 1000000, ErrorMessage = "Valor informado é inválido")]
    public int Quantity { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    

}
