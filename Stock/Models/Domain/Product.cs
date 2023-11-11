using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Stock.Models.Domain;

[Table(name:"Products")]
public class Product
{
    public Product()
    {
        RegistrationDate = DateTime.Now;
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string? Name { get; set; }

    [Required]
    [StringLength (100, MinimumLength = 10)]
    public string? Description { get; set; }

    [Required]
    [Range(0,1000000)]
    public int Quantity { get; set; }

    public DateTime RegistrationDate { get; private set; }

    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category Category { get; set; }
}
