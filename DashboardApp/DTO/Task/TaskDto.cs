namespace DashboardApp.DTO.Task
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string? TaskTitle { get; set; } 

        public string TaskText { get; set; } = null!;

        public int? AssignedUserId { get; set; }

        
    }
}
