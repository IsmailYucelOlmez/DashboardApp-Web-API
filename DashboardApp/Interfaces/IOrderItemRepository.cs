using DashboardApp.DTO.OrderItem;
using DashboardApp.Helpers;
using DashboardApp.Models;

namespace DashboardApp.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllAsync(OrderItemQueryObject query);
        Task<OrderItem?> GetByIdAsync(int id);
        Task<OrderItem?> GetByOrderIdAsync(int orderId);
        Task<OrderItem> CreateAsync(OrderItem orderModel);
        Task<OrderItem?> UpdateAsync(int id, CreateOrderItemRequsetDto orderDto);
        Task<OrderItem?> DeleteAsync(int id);
        Task<bool> OrderItemExistsAsync(int id);
    }
}
