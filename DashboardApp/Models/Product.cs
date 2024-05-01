using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PName")]
    [StringLength(50)]
    [Unicode(false)]
    public string Pname { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal StockAmount { get; set; }

    [Column("PImage", TypeName = "image")]
    public byte[]? Pimage { get; set; }

    [Column("PBrand")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Pbrand { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
