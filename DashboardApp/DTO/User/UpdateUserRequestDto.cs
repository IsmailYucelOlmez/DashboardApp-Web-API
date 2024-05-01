namespace DashboardApp.DTO.User
{
    public class UpdateUserRequestDto
    {

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public byte[]? Uimage { get; set; }

        public int? RoleId { get; set; }
    }
}
