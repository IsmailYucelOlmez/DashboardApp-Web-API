using DashboardApp.DTO.Product;
using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Interfaces;
using DashboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DashboardDbContext _context;

        public ProductRepository(DashboardDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(u => u.Id == id);

            if (productModel == null)
            {
                return null;
            }

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<List<Product>> GetAllAsync(ProductQueryObject query)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.ProductName))
            {
                products = products.Where(s => s.Pname.Contains(query.ProductName));
            }

            if (query.UnitPrice!=0)
            {
                products = products.Where(s => s.UnitPrice==query.UnitPrice);
            }


            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Product?> GetByProductNameAsync(string productName)
        {
            return await _context.Products.FirstOrDefaultAsync(u => u.Pname == productName);
        }

        public async Task<Product?> UpdateAsync(int id, CreateProductRequestDto productDto)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Pname = productDto.PName;
            existingProduct.Pbrand = productDto.PBrand;
            existingProduct.UnitPrice = productDto.UnitPrice;
            existingProduct.StockAmount = productDto.StockAmount;
            existingProduct.Pimage = productDto.PImage; 
           

            await _context.SaveChangesAsync();

            return existingProduct;
        }

        public Task<bool> ProductExistsAsync(int id)
        {
            return _context.Products.AnyAsync(s => s.Id == id);
        }
    }
}
