using Microsoft.Extensions.Logging;
using ONIS.Business.Order.Interfaces;
using ONIS.Data.Order.Services.Interfaces;
using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Business.Order.Services;

public class OrderServices : IOrderServices
{
    readonly IOrderRepository _orderRepository;
    readonly ILogger<OrderServices> _logger;
    public OrderServices(IOrderRepository orderRepository, ILogger<OrderServices> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async ValueTask<ResultObject<IOrderDTO>> GetOrdersAsync()
    {
        var result = new ResultObject<IOrderDTO>();
        IEnumerable<IOrderDTO> orderDto;

        try
        {
            orderDto = await _orderRepository.GetAllAsync();
            result.Result = orderDto;
            result.IsError = false;

        }
        catch (Exception ex)
        {
            _logger.LogError(message: $"Error en {this.ToString()} / ONIS.Bussines.Catalog.Services.ProductService.GetProductByIdAsync, Mensaje Especifico exception.Message {ex.Message}, exception.InnerEx {(ex.InnerException == null ? ex.InnerException : string.Empty)}");
            result.IsError = true;
            result.Message = "Error al obtener información";// ex.Message;

        }
        return result;
    }

    public async ValueTask<ResultObject<IOrderDTO>> GetOrderByIdAsync(int OrderId)
    {
        var result = new ResultObject<IOrderDTO>();
        IOrderDTO orderDto;
        try
        {
            orderDto = await _orderRepository.GetAsync(OrderId);
            result.Result = new List<IOrderDTO>() { orderDto };
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

    public async ValueTask<ResultObject<IOrderDTO>> InsertOrderAsync(IOrderDTO orderDTO)
    {
        var OrderResult = await _orderRepository.Add(orderDTO);// throw new NotImplementedException();

        var result = await GetOrderByIdAsync(OrderResult.Id);
        return result;
    }
}
