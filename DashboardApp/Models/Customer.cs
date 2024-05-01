using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Models;

public partial class Customer
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CName")]
    [StringLength(30)]
    [Unicode(false)]
    public string Cname { get; set; } = null!;

    [Column("CMail")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Cmail { get; set; }

    [Column("CPhone")]
    [StringLength(20)]
    [Unicode(false)]
    public string Cphone { get; set; } = null!;

    [Column("CBudget", TypeName = "decimal(10, 2)")]
    public decimal? Cbudget { get; set; }

    [Column("CImage", TypeName = "image")]
    public byte[]? Cimage { get; set; }

    [Column("CStatu")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Cstatu { get; set; }

    [Column("CLocation")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Clocation { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
