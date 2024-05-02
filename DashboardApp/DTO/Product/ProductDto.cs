﻿namespace DashboardApp.DTO.Product
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string PName { get; set; } = null!;

        public decimal UnitPrice { get; set; }

        public decimal StockAmount { get; set; }

        public byte[]? PImage { get; set; }

        public string? PBrand { get; set; }= null!;
    }
}
