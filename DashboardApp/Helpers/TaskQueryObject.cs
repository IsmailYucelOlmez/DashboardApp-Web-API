namespace DashboardApp.Helpers
{
    public class TaskQueryObject
    {
        public string? TaskTitle { get; set; } = null;
        public int AssignedUserId { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
