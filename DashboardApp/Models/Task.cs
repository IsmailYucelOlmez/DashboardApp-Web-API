using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Models;

public partial class Task
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TaskTitle { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string TaskText { get; set; } = null!;

    public int? AssignedUserId { get; set; }

    [ForeignKey("AssignedUserId")]
    [InverseProperty("Tasks")]
    public virtual User? AssignedUser { get; set; }
}
