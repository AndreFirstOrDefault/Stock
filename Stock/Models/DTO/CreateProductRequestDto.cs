using Stock.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Stock.Models.DTO;

public class CreateProductRequestDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
     
}
