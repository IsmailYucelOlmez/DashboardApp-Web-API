﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Models;

[Table("OrderItem")]
public partial class OrderItem
{
    [Key]
    [Column("OrderItemID")]
    public int OrderItemId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Amount { get; set; }

    [Column("ProductID")]
    public int? ProductId { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order? Order { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("OrderItems")]
    public virtual Product? Product { get; set; }
}
