namespace DashboardApp.Helpers
{
    public class EmployeeQueryObject
    {
        public string? EName { get; set; } = null;
        public string? Statu { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
