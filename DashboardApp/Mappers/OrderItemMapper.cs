using DashboardApp.DTO.OrderItem;
using DashboardApp.DTO.User;
using DashboardApp.Models;

namespace DashboardApp.Mappers
{
    public static class OrderItemMapper
    {
        public static OrderItemDto ToOrderItemDto(this OrderItem orderItemModel)
        {
            return new OrderItemDto
            {
                OrderItemId = orderItemModel.OrderItemId,
                Amount = orderItemModel.Amount,
                OrderId = orderItemModel.OrderId,
                ProductId = orderItemModel.ProductId,
               
            };
        }

        public static OrderItem ToOrderItemFromCreateDto(this CreateOrderItemRequsetDto orderItemDto)
        {
            return new OrderItem
            {
                OrderId = orderItemDto.OrderId,
                ProductId = orderItemDto.ProductId,
                Amount = orderItemDto.Amount,
                

            };
        }
    }
}
