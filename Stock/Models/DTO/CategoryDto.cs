using Stock.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Stock.Models.DTO;

// 7º

public class CategoryDto
{
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 5)]
    public string? Name { get; set; }

    [StringLength(100, MinimumLength = 5)]
    public string? Description { get; set; }

    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}
