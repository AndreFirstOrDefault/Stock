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

    [StringLength(50, MinimumLength = 5,ErrorMessage = "O nome precisa ter entre 5 e 50 caracteres.")]
    public string? Name { get; set; }

    [StringLength (100, MinimumLength = 10, ErrorMessage = "A descrição precisa ter entre 10 e 100 caracteres.")]
    public string? Description { get; set; }

    [Range(0,1000000,ErrorMessage = "Valor informado é inválido")]
    public int Quantity { get; set; }

    public DateTime RegistrationDate { get; private set; }

    [Required(ErrorMessage = "Informe o Id da Categoria")]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category Category { get; set; }
}
