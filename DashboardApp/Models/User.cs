using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Models;

public partial class User
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [StringLength(25)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("UImage", TypeName = "image")]
    public byte[]? Uimage { get; set; }

    [Column("RoleID")]
    public int? RoleId { get; set; }

    [InverseProperty("Receiver")]
    public virtual ICollection<Message> MessageReceivers { get; set; } = new List<Message>();

    [InverseProperty("Sender")]
    public virtual ICollection<Message> MessageSenders { get; set; } = new List<Message>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Urole? Role { get; set; }

    [InverseProperty("AssignedUser")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
