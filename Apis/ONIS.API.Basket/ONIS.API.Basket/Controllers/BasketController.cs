using Microsoft.AspNetCore.Mvc;
using ONIS.Business.Basket.Interfaces;
using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.Helpers;

namespace ONIS.API.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IBasketServices _basketServ;
    private readonly ILogger<BasketController> _logger;
    public BasketController(IBasketServices basketServ, ILogger<BasketController> logger)
    {
        _basketServ = basketServ;
        _logger = logger;
    }
    [HttpGet(Name = "GetBaskets")]
    public async Task<ActionResult<ResultObject<BasketDTO>>> GetBaskets()
    {
        var result = await _basketServ.GetBasketsAsync();
        return Ok(result);
    }
    [HttpGet("{basketId}", Name = "GetBasket")]
    public async Task<ActionResult<ResultObject<BasketDTO>>> GetBasket(int basketId)
    {
        var result = await _basketServ.GetBasketByIdAsync(basketId);
        return Ok(result);
    }
    [HttpPost(Name = "AddNewBasket")]
    public async Task<IActionResult> AddNewBasket(BasketDTO basket)
    {
        await _basketServ.InsertBasketAsync(basket);
        var result = await _basketServ.GetBasketByIdAsync(basket.Id);
        return Ok(result);
    }


}
