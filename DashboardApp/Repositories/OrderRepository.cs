using DashboardApp.DTO.Order;
using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Interfaces;
using DashboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DashboardDbContext _context;

        public OrderRepository(DashboardDbContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateAsync(Order orderModel)
        {
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<Order?> DeleteAsync(int id)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(u => u.OrderId == id);

            if (orderModel == null)
            {
                return null;
            }

            _context.Orders.Remove(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<List<Order>> GetAllAsync(OrderQueryObject query)
        {
            var orders = _context.Orders.AsQueryable();

            if (query.CustomerId!=0)
            {
                orders = orders.Where(s => s.CustomerId==query.CustomerId);
            }

            if (query.OrderDate != null)
            {
                orders = orders.Where(s => s.OrderDate == query.OrderDate);
            }


            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await orders.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(u => u.OrderId == id);
        }

        public async Task<Order?> GetByOrderDateAsync(DateTime date)
        {
            return await _context.Orders.FirstOrDefaultAsync(u => u.OrderDate == date);
        }

        public Task<bool> OrderExistsAsync(int id)
        {
            return _context.Orders.AnyAsync(s => s.OrderId == id);
        }

        public async Task<Order?> UpdateAsync(int id, CreateOrderRequestDto orderDto)
        {
            var existingOrder = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);

            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.CustomerId = orderDto.CustomerId;
            existingOrder.TotalPrice = orderDto.TotalPrice;
            existingOrder.OrderStatu = orderDto.OrderStatu;
            existingOrder.OrderDate = orderDto.OrderDate;
            

            await _context.SaveChangesAsync();

            return existingOrder;
        }
    }
}
