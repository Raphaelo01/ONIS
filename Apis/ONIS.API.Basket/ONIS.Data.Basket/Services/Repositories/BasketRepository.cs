using Microsoft.EntityFrameworkCore;
using ONIS.Data.Basket.Context;
using ONIS.Data.Basket.Entities;
using ONIS.Data.Basket.Services.Interfaces;
using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.DTOs.NullDTOs;

namespace ONIS.Data.Basket.Services.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly BasketDBContext _context;
    public BasketRepository(BasketDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async ValueTask<IBasketDTO> Add(IBasketDTO basketDTO)
    {
        var basket = new BasketCatalog()
        {
            Id = basketDTO.Id,
            BuyerId = basketDTO.BuyerId,
            OrderDate = basketDTO.OrderDate,
        };
        await _context.Baskets.AddAsync(basket);//_context.Orders.AddAsync(order);
        await SaveChanges();
        basketDTO.Id = basket.Id;
        return basketDTO;
    }

    public async Task<IEnumerable<IBasketDTO>> GetAllAsync()
    {
        var result = await _context.Baskets.Include(i => i.Items).ToListAsync();
        return result.Select(p => new BasketDTO()
        {
            Id = p.Id,
            BuyerId = p.BuyerId,
            OrderDate = p.OrderDate,
            Items = p.Items?.Select(it => new BasketItemDTO() { Id = it.Id, BasketId = it.BasketId, ProductId = it.ProductId, Quantity = it.Quantity }).ToList()
        });
    }
    public async Task<IBasketDTO> GetAsync(int Id)
    {
        IBasketDTO resultDTO = new BasketDTO();
        try
        {
            var result = await _context.Baskets.Where(p => p.Id == Id).FirstOrDefaultAsync();//.Include("OrderItem").Include("Address").FirstOrDefaultAsync();
            if (result == null)
                return new NullBasketDTO();


            resultDTO = new BasketDTO()
            {
                BuyerId = result.BuyerId,
                OrderDate = result.OrderDate,
                Id = Id
            };
            var basketitems = result.Items != null && result.Items.Any() ? _context.BasketItems.Where(p => p.BasketId == Id).ToList() : new List<BasketItem>(); ;
            var basketItemsDTO = new List<BasketItemDTO>();
            if (basketitems != null)
                foreach (var item in basketitems)
                    basketItemsDTO.Add(new BasketItemDTO() { ProductId = item.ProductId, Quantity = item.Quantity });

        }
        catch (Exception ex)
        {

        }

        return resultDTO;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
