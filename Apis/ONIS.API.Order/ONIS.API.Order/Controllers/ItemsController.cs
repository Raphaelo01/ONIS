using Microsoft.AspNetCore.Mvc;
using ONIS.Business.Order.Interfaces;
using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.Helpers;

namespace ONIS.API.Order.Controllers;

[Route("api/Order/{OrderId}/Items")]
[ApiController]
public class ItemsController : ControllerBase
{

    private readonly IOrderItemServices _OrderItemServ;
    private readonly ILogger<OrderController> _logger;
    public ItemsController(IOrderItemServices orderItemServices, ILogger<OrderController> logger)
    {
        _OrderItemServ = orderItemServices;
        _logger = logger;
    }

    [HttpGet(Name = "GetItems")]
    public async Task<ActionResult<ResultObject<OrderItemDTO>>> GetItems(int OrderId)
    {
        _logger.LogError(message: $"Este es un log en el enpoint Product->GetProducts como ejemplo");
        //throw new NotImplementedException(" una exepcion no controlada en el sistema ");
        return Ok(await _OrderItemServ.GetOrderItemsByOrderIdAsync(OrderId));
    }
    [HttpPost(Name = "AddNewItem")]
    public async Task<IActionResult> AddNewItem(int OrderId, OrderItemDTO orderItem)
    {
        //await _OrderItemServ.InsertOrderAsync(order);
        var result = await _OrderItemServ.InsertOrderItemAsync(OrderId, orderItem);
        return Ok(result);
    }

}
