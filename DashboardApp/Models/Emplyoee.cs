using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Models;

[Table("Emplyoee")]
public partial class Emplyoee
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("EName")]
    [StringLength(50)]
    [Unicode(false)]
    public string Ename { get; set; } = null!;

    [Column("EPhone")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Ephone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LeaveDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime HireDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Job { get; set; } = null!;

    [Column("PImage", TypeName = "image")]
    public byte[]? Pimage { get; set; }

    [Column("EStatu")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Estatu { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Mail { get; set; }

    [Column("ELocation")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Elocation { get; set; }
}
