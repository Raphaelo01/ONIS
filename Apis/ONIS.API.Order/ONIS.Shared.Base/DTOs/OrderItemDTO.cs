using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Shared.Base.DTOs;

public class OrderItemDTO : IOrderItemDTO
{

    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    //public OrderDTO? Order { get; set; }

}
