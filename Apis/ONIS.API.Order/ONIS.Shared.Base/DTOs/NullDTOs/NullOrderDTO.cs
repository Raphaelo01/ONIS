using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Shared.Base.DTOs.NullDTOs;

public class NullOrderDTO : IOrderDTO
{
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public string FullAddress { get; set; } = string.Empty;
    public IEnumerable<IOrderItemDTO>? Items { get; set; }
    public int IdAddress { get; set; }
}
