using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Shared.Base.DTOs;

public class BasketItemDTO : IBasketItemDTO
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int BasketId { get; set; }
    public int ProductId { get; set; }
}
