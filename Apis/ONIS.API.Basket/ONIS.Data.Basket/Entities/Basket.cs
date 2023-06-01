using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONIS.Data.Basket.Entities;

[Table("Basket")]
public class BasketCatalog
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    public int BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public IEnumerable<BasketItem>? Items { get; set; }
}
