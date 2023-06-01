using Microsoft.AspNetCore.Mvc;
using ONIS.Business.Basket.Interfaces;
using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.Helpers;

namespace ONIS.API.Basket.Controllers;

[Route("api/Basket/Items")]
[ApiController]
public class BasketItemsController : ControllerBase
{
    private readonly IBasketItemService _basketItemServ;
    private readonly ILogger<BasketItemsController> _logger;

    public BasketItemsController(IBasketItemService basketItemServ, ILogger<BasketItemsController> logger)
    {
        _basketItemServ = basketItemServ;
        _logger = logger;
    }
    [HttpGet(Name = "GetItems")]
    public async Task<ActionResult<ResultObject<BasketItemDTO>>> GetItems(int BasketId)
    {
        var result = await _basketItemServ.GetBasketItemsByBasketIdAsync(BasketId);
        return Ok(result);
    }
    [HttpPost(Name = "AddNewItem")]
    public async Task<IActionResult> AddNewItem(int BasketId, BasketItemDTO basketItem)
    {
        var result = await _basketItemServ.InsertBasketItemAsync(BasketId, basketItem);
        return Ok(result);
    }

}
