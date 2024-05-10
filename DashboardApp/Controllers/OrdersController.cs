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
using DashboardApp.DTO.Order;
using DashboardApp.DTO.User;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DashboardDbContext _context;

        private readonly IOrderRepository _orderRepository;

        public OrdersController(DashboardDbContext context,IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders([FromQuery] OrderQueryObject query)
        {
            var orders = await _orderRepository.GetAllAsync(query);

            var orderdto = orders.Select(s => s.ToOrderDto()).ToList();

            return Ok(orderdto);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order.ToOrderDto());
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, CreateOrderRequestDto orderDto)
        {
            var orderModel = await _orderRepository.UpdateAsync(id, orderDto);

            if (orderModel == null)
            {
                return NotFound();
            }


            return Ok(orderModel.ToOrderDto());
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromBody] CreateOrderRequestDto orderDto)
        {
            var orderModel = orderDto.ToOrderFromCreateDto();
            
            await _orderRepository.CreateAsync(orderModel);

            return CreatedAtAction("GetOrder", new { id = orderModel.OrderId }, orderModel.ToOrderDto());
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderRepository.DeleteAsync(id);
            if (order == null)
            {
                return NotFound();
            }


            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
