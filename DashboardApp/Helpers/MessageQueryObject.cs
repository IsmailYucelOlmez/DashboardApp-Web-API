namespace DashboardApp.Helpers
{
    public class MessageQueryObject
    {
        public string? MessageTitle { get; set; } = null;
        public int ReceiverId { get; set; } 
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
