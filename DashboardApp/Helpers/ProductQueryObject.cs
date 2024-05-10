namespace DashboardApp.Helpers
{
    public class ProductQueryObject
    {
        public string?  ProductName { get; set; } = null;
        public int UnitPrice { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
