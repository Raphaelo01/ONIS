namespace ONIS.Shared.Base.DTOs.Interfaces;

public interface IOrderItemDTO
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    //public OrderDTO Order { get; set; }
    public int ProductId { get; set; }
    //public IEnumerable<ProductDTO>? Products { get; set; }
}
