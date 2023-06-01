using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONIS.Data.Order.Entities;

public class OrderItem
{


    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    // Foreign key de la entidad Order
    public int Quantity { get; set; }

    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }

}
