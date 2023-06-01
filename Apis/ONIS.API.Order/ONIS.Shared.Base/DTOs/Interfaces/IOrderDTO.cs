namespace ONIS.Shared.Base.DTOs.Interfaces
{
    public interface IOrderDTO
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int IdAddress { get; set; }
        public string FullAddress { get; set; }
        public IEnumerable<IOrderItemDTO>? Items { get; set; }
    }
}
