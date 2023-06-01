using Microsoft.Extensions.Logging;
using ONIS.Business.Order.Interfaces;
using ONIS.Data.Order.Services.Interfaces;
using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Business.Order.Services;

public class OrderItemServices : IOrderItemServices
{
    readonly IOrderItemRepository _orderItemRepository;
    readonly ILogger<OrderItemServices> _logger;
    public OrderItemServices(IOrderItemRepository orderItemRepository, ILogger<OrderItemServices> logger)
    {
        _orderItemRepository = orderItemRepository;
        _logger = logger;
    }


    public async ValueTask<ResultObject<IOrderItemDTO>> GetOrderItemsByOrderIdAsync(int OrderId)
    {
        var result = new ResultObject<IOrderItemDTO>();
        IEnumerable<IOrderItemDTO> orderItemDto;
        try
        {
            orderItemDto = await _orderItemRepository.GetAllAsync(OrderId);
            result.Result = orderItemDto;
            result.IsError = false;
            //= await _productRepository.GetAsync(idProduct);
        }
        catch (Exception ex)
        {
            result.IsError = true;
            result.Message = "Error al obtener información";// ex.Message;
            _logger.LogError(message: $"Error en {this.ToString()} / ONIS.Bussines.Order.Services.OrderService.GetOrderByIdAsync, Mensaje Especifico exception.Message {ex.Message}, exception.InnerEx {(ex.InnerException == null ? ex.InnerException : string.Empty)}");
        }
        return result;
    }
    public async ValueTask<ResultObject<IOrderItemDTO>> InsertOrderItemAsync(int orderId, IOrderItemDTO orderItemDTO)
    {
        await _orderItemRepository.AddAsync(orderItemDTO);// throw new NotImplementedException();

        var result = await GetOrderItemsByOrderIdAsync(orderId);
        return result;
    }

}
