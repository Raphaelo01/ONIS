using Microsoft.EntityFrameworkCore;
using ONIS.Data.Basket.Context;
using ONIS.Data.Basket.Entities;
using ONIS.Data.Basket.Services.Interfaces;
using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Data.Basket.Services.Repositories;

public class BasketItemRepository : IBasketItemRepository
{
    private readonly BasketDBContext _context;
    public BasketItemRepository(BasketDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async ValueTask AddAsync(IBasketItemDTO basketItemDTO)
    {
        await _context.BasketItems.AddAsync(new BasketItem()
        {
            BasketId = basketItemDTO.BasketId,
            ProductId = basketItemDTO.ProductId,
            Quantity = basketItemDTO.Quantity
        });

        await SaveChanges();
    }

    public async Task<IEnumerable<IBasketItemDTO>> GetAllAsync(int basketId)
    {
        var result = await _context.BasketItems.Where(p => p.BasketId == basketId).ToListAsync();
        return result.Select(p => new BasketItemDTO()
        {
            Id = p.Id,
            ProductId = p.ProductId,
            Quantity = p.Quantity,
            BasketId = p.BasketId
        });
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
