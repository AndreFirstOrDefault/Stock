using System.ComponentModel.DataAnnotations;

namespace Stock.Models.DTO;

public class ProductDto
{
    public ProductDto()
    {
        RegistrationDate = DateTime.Now;
    }

    [Key]
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 5)]
    public string? Name { get; set; }

    [StringLength(100, MinimumLength = 10)]
    public string? Description { get; set; }

    [Range(0, 1000000)]
    public int Quantity { get; set; }

    public DateTime RegistrationDate { get; private set; }

    public int CategoryId { get; set; }

}
