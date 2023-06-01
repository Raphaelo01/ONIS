using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Business.Order.Interfaces;

public interface IOrderItemServices
{
    //public ValueTask<ResultObject<IOrderItemDTO>> GetOrderItemAsync();
    public ValueTask<ResultObject<IOrderItemDTO>> GetOrderItemsByOrderIdAsync(int OrderId);
    public ValueTask<ResultObject<IOrderItemDTO>> InsertOrderItemAsync(int orderId, IOrderItemDTO orderItemDTO);
    //public ValueTask DeleteOrderItemAsync(int orderItemID);
    //public ValueTask<ResultObject<IOrderItemDTO>> UpdateOrderItemAsync(int orderItemId, IOrderItemDTO orderItemDTO);
}
