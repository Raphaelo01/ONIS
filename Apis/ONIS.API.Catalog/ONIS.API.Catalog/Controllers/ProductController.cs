using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ONIS.Bussines.Catalog.Interfaces;

using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.Helpers;

namespace ONIS.API.Catalog.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly IProductService _productServ;
    private readonly ILogger<ProductController> _logger;
    public ProductController(IProductService product, ILogger<ProductController> logger)
    {
        _productServ = product;
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<ActionResult<ResultObject<ProductDTO>>> GetProducts()
    {
        _logger.LogError(message: $"Este es un log en el enpoint Product->GetProducts como ejemplo");
        //throw new NotImplementedException(" una exepcion no controlada en el sistema ");
        return Ok(await _productServ.GetProductsAsync());
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<ActionResult<ResultObject<ProductDTO>>> GetProductById(int id)
    {
        var product = await _productServ.GetProductByIdAsync(id);
        return Ok(product);
    }
    [HttpPost(Name = "AddNewProduct")]
    public async Task<IActionResult> AddNewProduct(ProductDTO product)
    {
        await _productServ.InsertAsync(product);

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteProductById")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productServ.DeleteProductAsync(id);

        return NoContent();
    }
    [HttpPatch("{id}", Name = "UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
    {
        var currentProduct = await _productServ.GetProductByIdAsync(id);
        await _productServ.UpdateProductAsync(id, productDTO);
        return NoContent();
    }


}
