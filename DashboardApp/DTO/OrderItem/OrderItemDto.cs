namespace DashboardApp.DTO.OrderItem
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }

        public decimal? Amount { get; set; }

        public int? ProductId { get; set; }

        public int? OrderId { get; set; }

    }
}
