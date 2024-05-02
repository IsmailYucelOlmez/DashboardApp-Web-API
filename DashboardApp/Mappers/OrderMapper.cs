using DashboardApp.DTO.Order;
using DashboardApp.DTO.User;
using DashboardApp.Models;

namespace DashboardApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToUserDto(this Order orderModel)
        {
            return new OrderDto
            {
                Id = orderModel.OrderId,
                OrderDate = orderModel.OrderDate,
                CustomerId = orderModel.CustomerId,
                OrderStatu = orderModel.OrderStatu,
                TotalPrice = orderModel.TotalPrice,
                

            };
        }

        public static Order ToUserFromCreateDto(this CreateOrderRequestDto orderDto)
        {
            return new Order
            {
                OrderDate = orderDto.OrderDate,
                OrderStatu = orderDto.OrderStatu,
                CustomerId = orderDto.CustomerId,
                TotalPrice = orderDto.TotalPrice,
              
            };
        }
    }
}
