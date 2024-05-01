using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DashboardApp.DTO.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public byte[]? Uimage { get; set; }

        public int? RoleId { get; set; }

    }
}
