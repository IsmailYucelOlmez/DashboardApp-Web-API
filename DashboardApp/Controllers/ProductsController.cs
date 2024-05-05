using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashboardApp.Models;
using DashboardApp.Interfaces;
using DashboardApp.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using DashboardApp.Helpers;
using DashboardApp.Mappers;
using DashboardApp.DTO.Product;
using DashboardApp.DTO.User;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DashboardDbContext _context;

        private readonly IProductRepository _productRepository;

        public ProductsController(DashboardDbContext context, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] ProductQueryObject query)
        {
            var products = await _productRepository.GetAllAsync(query);

            var productdto = products.Select(s => s.ToProductDto()).ToList();

            return Ok(productdto);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToProductDto());
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, CreateProductRequestDto productDto)
        {
            var productModel = await _productRepository.UpdateAsync(id, productDto);

            if (productModel == null)
            {
                return NotFound();
            }


            return Ok(productModel.ToProductDto());
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] CreateProductRequestDto productDto)
        {
            var productModel = productDto.ToProductFromCreateDto();

            await _productRepository.CreateAsync(productModel);

            return CreatedAtAction("GetUser", new { id = productModel.Id }, productModel.ToProductDto());
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.DeleteAsync(id);
            if (product == null)
            {
                return NotFound();
            }


            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
