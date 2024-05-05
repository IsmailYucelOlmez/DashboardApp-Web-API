using DashboardApp.DTO.OrderItem;
using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Interfaces;
using DashboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DashboardDbContext _context;

        public OrderItemRepository(DashboardDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> CreateAsync(OrderItem orderModel)
        {
            await _context.OrderItems.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<OrderItem?> DeleteAsync(int id)
        {
            var orderItemModel = await _context.OrderItems.FirstOrDefaultAsync(u => u.OrderItemId == id);

            if (orderItemModel == null)
            {
                return null;
            }

            _context.OrderItems.Remove(orderItemModel);
            await _context.SaveChangesAsync();
            return orderItemModel;
        }

        public async Task<List<OrderItem>> GetAllAsync(OrderItemQueryObject query)
        {
            var orderItems = _context.OrderItems.AsQueryable();

            if (query.OrderId!=0)
            {
                orderItems = orderItems.Where(s => s.OrderId==query.OrderId);
            }

            if (query.ProductId != 0)
            {
                orderItems = orderItems.Where(s => s.ProductId == query.OrderId);
            }


            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await orderItems.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(u => u.OrderItemId == id);
        }

        public async Task<OrderItem?> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(u => u.OrderId == orderId);
        }

        public Task<bool> OrderItemExistsAsync(int id)
        {
            return _context.OrderItems.AnyAsync(s => s.OrderItemId == id);
        }

        public async Task<OrderItem?> UpdateAsync(int id, CreateOrderItemRequsetDto orderDto)
        {
            var existingOrderItem = await _context.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);

            if (existingOrderItem == null)
            {
                return null;
            }

            existingOrderItem.OrderId = orderDto.OrderId;
            existingOrderItem.ProductId = orderDto.ProductId;
            existingOrderItem.Amount = orderDto.Amount;
          

            await _context.SaveChangesAsync();

            return existingOrderItem;
        }
    }
}
