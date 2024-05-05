namespace DashboardApp.Helpers
{
    public class OrderItemQueryObject
    {
        public int OrderId { get; set; } 
        public int ProductId { get; set; } 
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
