using Microsoft.AspNetCore.Mvc;
using ONIS.Business.Order.Interfaces;
using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.Helpers;

namespace ONIS.API.Order.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderServices _OrderServ;
    private readonly ILogger<OrderController> _logger;
    public OrderController(IOrderServices orderServ, ILogger<OrderController> logger)
    {
        _OrderServ = orderServ;
        _logger = logger;
    }
    [HttpGet(Name = "GetOrders")]
    public async Task<ActionResult<ResultObject<OrderDTO>>> GetOrders()
    {
        _logger.LogError(message: $"Este es un log en el enpoint Product->GetProducts como ejemplo");
        //throw new NotImplementedException(" una exepcion no controlada en el sistema ");
        return Ok(await _OrderServ.GetOrdersAsync());
    }
    [HttpPost(Name = "AddNewOrder")]
    public async Task<IActionResult> AddNewOrder(OrderDTO order)
    {
        await _OrderServ.InsertOrderAsync(order);
        var result = _OrderServ.GetOrderByIdAsync(order.Id);
        return Ok(result);
    }
    //[HttpPost(Name = "AddNewOrderItem")]
    //public async Task<IActionResult> AddOrderItem(OrderItemDTO orderItemDTO)
    //{
    //    await _OrderItemServ.InsertOrderItemAsync(orderItemDTO);
    //    //var result =_OrderServ.GetOrderByIdAsync .GetOrderItemByIdAsync.GetOrderByIdAsync(order.Id);
    //    return NoContent();
    //}

}
