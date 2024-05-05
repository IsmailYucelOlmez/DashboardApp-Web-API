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
using DashboardApp.DTO.OrderItem;
using DashboardApp.Helpers;
using DashboardApp.Mappers;
using DashboardApp.DTO.User;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly DashboardDbContext _context;

        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemsController(DashboardDbContext context, IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems([FromQuery] OrderItemQueryObject query)
        {
            var orderItems = await _orderItemRepository.GetAllAsync(query);

            var orderItemDto = orderItems.Select(s => s.ToOrderItemDto()).ToList();

            return Ok(orderItemDto);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, CreateOrderItemRequsetDto orderItemDto)
        {
            var orderItemModel = await _orderItemRepository.UpdateAsync(id, orderItemDto);

            if (orderItemModel == null)
            {
                return NotFound();
            }


            return Ok(orderItemModel.ToOrderItemDto());
        }

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem([FromBody] CreateOrderItemRequsetDto orderItemDto)
        {
            var orderItemModel = orderItemDto.ToOrderItemFromCreateDto();

            await _orderItemRepository.CreateAsync(orderItemModel);

            return CreatedAtAction("GetOrderItem", new { id = orderItemModel.OrderItemId }, orderItemModel.ToOrderItemDto());
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await _orderItemRepository.DeleteAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }


            return NoContent();
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItems.Any(e => e.OrderItemId == id);
        }
    }
}
