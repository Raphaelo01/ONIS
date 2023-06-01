using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Business.Order.Interfaces;

public interface IOrderServices
{
    public ValueTask<ResultObject<IOrderDTO>> GetOrdersAsync();
    public ValueTask<ResultObject<IOrderDTO>> GetOrderByIdAsync(int idProduct);
    public ValueTask<ResultObject<IOrderDTO>> InsertOrderAsync(IOrderDTO orderDTO);
    //public ValueTask DeleteOrderAsync(int orderID);
    //public ValueTask<ResultObject<IOrderDTO>> UpdateOrderAsync(int orderId, IOrderDTO orderDTO);
}
