using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONIS.Data.Basket.Entities;

public class BasketItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    // Foreign key de la entidad Order
    public int Quantity { get; set; }

    [ForeignKey("BasketId")]
    public int BasketId { get; set; }
    public BasketCatalog Basket { get; set; }

    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }

}