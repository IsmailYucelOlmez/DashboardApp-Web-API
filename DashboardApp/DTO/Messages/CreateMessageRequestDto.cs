namespace DashboardApp.DTO.Messages
{
    public class CreateMessageRequestDto
    {
        public string? MessageTitle { get; set; } 

        public string MessageText { get; set; } = null!;

        public int? SenderId { get; set; }

        public int? ReceiverId { get; set; }

    }
}
