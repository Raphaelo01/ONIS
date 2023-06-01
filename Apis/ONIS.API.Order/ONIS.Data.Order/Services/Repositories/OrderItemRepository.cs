using Microsoft.EntityFrameworkCore;
using ONIS.Data.Order.Context;
using ONIS.Data.Order.Entities;
using ONIS.Data.Order.Services.Interfaces;
using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Data.Order.Services.Repositories;
public class OrderItemRepository : IOrderItemRepository
{
    private readonly OrdersDbContext _context;
    public OrderItemRepository(OrdersDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async ValueTask AddAsync(IOrderItemDTO orderItemDTO)
    {
        /*var newProducts = new Product();
        var listOfProducts = new List<Product>();
        if (orderItemDTO != null && orderItemDTO.Products != null)
        {
            foreach (var itemProduct in orderItemDTO.Products)
            {
                newProducts = new Product()
                {
                    AvailableStock = itemProduct.AvailableStock,

                };

            }
        }*/

        await _context.OrderItems.AddAsync(new OrderItem()
        {
            OrderId = orderItemDTO.OrderId,
            ProductId = orderItemDTO.ProductId,
            Quantity = orderItemDTO.Quantity
        });
        await SaveChanges();
    }
    public async Task<IEnumerable<IOrderItemDTO>> GetAllAsync(int OrderId)
    {
        var result = await _context.OrderItems.Where(p => p.OrderId == OrderId).ToListAsync();
        return result.Select(p => new OrderItemDTO()
        {
            Id = p.Id,
            ProductId = p.ProductId,
            Quantity = p.Quantity
        });
    }
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }


}
