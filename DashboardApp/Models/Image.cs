using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Models;

public partial class Image
{
    [Key]
    [Column("ImageID")]
    public int ImageId { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Imagee { get; set; }
}
