using Microsoft.EntityFrameworkCore;
using ONIS.Data.Order.Context;
using ONIS.Data.Order.Entities;
//using ONIS.Data.Order.Entities;
using ONIS.Data.Order.Services.Interfaces;
using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.DTOs.NullDTOs;

namespace ONIS.Data.Order.Services.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrdersDbContext _context;

    public OrderRepository(OrdersDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async ValueTask<IOrderDTO> Add(IOrderDTO orderDto)
    {
        var order = new Entities.Order()
        {
            AddressId = orderDto.IdAddress,
            BuyerId = orderDto.BuyerId,
            OrderDate = orderDto.OrderDate,
        };
        await _context.Orders.AddAsync(order);
        await SaveChanges();
        orderDto.Id = order.Id;
        //var result = //await GetAsync(order.Id);
        return orderDto;
    }
    public async Task<IEnumerable<IOrderDTO>> GetAllAsync()
    {
        var result = await _context.Orders.Include(i => i.ShipToAddress).Include(i => i.Items).ToListAsync();
        return result.Select(p => new OrderDTO()
        {
            Id = p.Id,
            IdAddress = p.AddressId,
            BuyerId = p.BuyerId,
            FullAddress = p.ShipToAddress == null ? string.Empty : p.ShipToAddress.FullAddress,// "Campo pendiente de actualización",//
            OrderDate = p.OrderDate,
            Items = p.Items?.Select(it => new OrderItemDTO() { Id = it.Id, OrderId = it.OrderId, ProductId = it.ProductId, Quantity = it.Quantity }).ToList()

        });
    }

    public async Task<IOrderDTO> GetAsync(int Id)
    {

        IOrderDTO resultDTO = new OrderDTO();
        try
        {
            var result = await _context.Orders.Where(p => p.Id == Id).FirstOrDefaultAsync();//.Include("OrderItem").Include("Address").FirstOrDefaultAsync();
            if (result == null)
                return new NullOrderDTO();

            var AddressShipData = new Address();
            if (result.AddressId != null && result.AddressId > 0)
                AddressShipData = await _context.Address.Where(p => p.Id == result.AddressId).FirstOrDefaultAsync();


            resultDTO = new OrderDTO()
            {
                IdAddress = result.AddressId,
                BuyerId = result.BuyerId,
                FullAddress = AddressShipData == null ? string.Empty : AddressShipData.FullAddress,
                OrderDate = result.OrderDate,
                Id = Id
            };
            var orderitems = result.Items != null && result.Items.Any() ? _context.OrderItems.Where(p => p.OrderId == Id).ToList() : new List<OrderItem>(); ;
            var orderItemsDTO = new List<OrderItemDTO>();
            if (orderitems != null)
                foreach (var item in orderitems)
                    orderItemsDTO.Add(new OrderItemDTO() { ProductId = item.ProductId, Quantity = item.Quantity });

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
