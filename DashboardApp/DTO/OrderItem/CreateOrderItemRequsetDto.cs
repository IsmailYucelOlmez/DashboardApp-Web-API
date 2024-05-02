namespace DashboardApp.DTO.OrderItem
{
    public class CreateOrderItemRequsetDto
    {
        public decimal? Amount { get; set; }

        public int? ProductId { get; set; }

        public int? OrderId { get; set; }
    }
}
