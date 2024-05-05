using DashboardApp.DTO.Product;
using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Models;

namespace DashboardApp.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(ProductQueryObject query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetByProductNameAsync(string symbol);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(int id, CreateProductRequestDto productDto);
        Task<Product?> DeleteAsync(int id);
        Task<bool> ProductExistsAsync(int id);
    }
}
