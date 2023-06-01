using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONIS.Data.Order.Entities;

public class Order
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    public int BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    [ForeignKey("AddressId")]
    public int AddressId { get; set; }
    public virtual Address? ShipToAddress { get; set; }
    public IEnumerable<OrderItem>? Items { get; set; }
}
