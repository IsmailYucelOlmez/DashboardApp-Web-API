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
using DashboardApp.DTO.Customer;
using DashboardApp.DTO.User;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DashboardDbContext _context;

        private readonly ICustomerRepository _customerRepository;

        public CustomersController(DashboardDbContext context, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers([FromQuery] CustomerQueryObject query)
        {
            var customers = await _customerRepository.GetAllAsync(query);

            var customerdto = customers.Select(s => s.ToCustomerDto()).ToList();

            return Ok(customerdto);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer.ToCustomerDto());
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CreateCustomerRequestDto customerdto)
        {
            var customerModel = await _customerRepository.UpdateAsync(id, customerdto);

            if (customerModel == null)
            {
                return NotFound();
            }


            return Ok(customerModel.ToCustomerDto());
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CreateCustomerRequestDto customerdto)
        {
            var customerModel = customerdto.ToCustomerFromCreateDto();

            await _customerRepository.CreateAsync(customerModel);

            return CreatedAtAction("GetCustomer", new { id = customerModel.Id }, customerModel.ToCustomerDto());
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var user = await _customerRepository.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
