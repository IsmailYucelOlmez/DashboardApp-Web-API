using DashboardApp.DTO.Product;
using DashboardApp.DTO.User;
using DashboardApp.Models;

namespace DashboardApp.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                PName = productModel.Pname,
                StockAmount = productModel.StockAmount,
                UnitPrice = productModel.UnitPrice,
                PImage = productModel.Pimage,
                PBrand = productModel.Pbrand,
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductRequestDto productDto)
        {
            return new Product
            {
                
                Pname = productDto.PName,
                StockAmount = productDto.StockAmount,
                UnitPrice = productDto.UnitPrice,
                Pimage = productDto.PImage,
                Pbrand = productDto.PBrand,

            };
        }
    }
}
