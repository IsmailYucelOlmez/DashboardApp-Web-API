using DashboardApp.DTO.Order;
using DashboardApp.Helpers;
using DashboardApp.Models;

namespace DashboardApp.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync(OrderQueryObject query);
        Task<Order?> GetByIdAsync(int id);
        Task<Order?> GetByOrderDateAsync(DateTime date);
        Task<Order> CreateAsync(Order orderModel);
        Task<Order?> UpdateAsync(int id, CreateOrderRequestDto orderDto);
        Task<Order?> DeleteAsync(int id);
        Task<bool> OrderExistsAsync(int id);
    }
}
