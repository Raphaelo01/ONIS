namespace ONIS.Shared.Base.DTOs.Interfaces;

public interface IBasketDTO
{
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public IEnumerable<IBasketItemDTO>? Items { get; set; }
}
