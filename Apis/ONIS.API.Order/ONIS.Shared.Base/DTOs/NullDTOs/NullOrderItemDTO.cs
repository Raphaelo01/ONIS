using ONIS.Shared.Base.DTOs.Interfaces;

public class NullOrderItemDTO : IOrderItemDTO
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }

    public int ProductId { get; set; }
}
