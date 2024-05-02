namespace DashboardApp.DTO.Task
{
    public class CreateTaskRequestDto
    {
        public string? TaskTitle { get; set; }

        public string TaskText { get; set; } = null!;

        public int? AssignedUserId { get; set; }
    }
}
