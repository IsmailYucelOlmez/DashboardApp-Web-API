namespace DashboardApp.DTO.Order
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime? OrderDate { get; set; } 

        public decimal? TotalPrice { get; set; }

        public string? OrderStatu { get; set; }      

        public int? CustomerId { get; set; }
    }
}
