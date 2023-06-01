using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Shared.Base.DTOs.NullDTOs;

public class NullBasketDTO : IBasketDTO
{
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public IEnumerable<IBasketItemDTO>? Items { get; set; }
    public DateTimeOffset OrderDate { get; set; }
}
