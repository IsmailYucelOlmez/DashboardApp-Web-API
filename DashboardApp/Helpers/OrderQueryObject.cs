namespace DashboardApp.Helpers
{
    public class OrderQueryObject
    {
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
