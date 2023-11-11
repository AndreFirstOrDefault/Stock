using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Stock.Models.Domain;

// 5º

[Table(name:"Categories")]
public class Category
{
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 5)]
    public string? Name { get; set; }

    [StringLength(100, MinimumLength = 10)]
    public string? Description { get; set; }

    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}
