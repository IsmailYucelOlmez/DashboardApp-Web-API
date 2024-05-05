using DashboardApp.DTO.Customer;
using DashboardApp.Helpers;
using DashboardApp.Interfaces;
using DashboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DashboardDbContext _context;

        public CustomerRepository(DashboardDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateAsync(Customer customerModel)
        {
            await _context.Customers.AddAsync(customerModel);
            await _context.SaveChangesAsync();
            return customerModel;
        }

        public async Task<Customer?> DeleteAsync(int id)
        {
            var customerModel = await _context.Customers.FirstOrDefaultAsync(u => u.Id == id);

            if (customerModel == null)
            {
                return null;
            }

            _context.Customers.Remove(customerModel);
            await _context.SaveChangesAsync();
            return customerModel;
        }

        public async Task<List<Customer>> GetAllAsync(CustomerQueryObject query)
        {
            var customers = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CName))
            {
                customers = customers.Where(s => s.Cname.Contains(query.CName));
            }

            if (!string.IsNullOrWhiteSpace(query.CStatu))
            {
                customers = customers.Where(s => s.Cstatu.Contains(query.CStatu));
            }


            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await customers.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Customer?> GetByCustomerNameAsync(string CName)
        {
            return await _context.Customers.FirstOrDefaultAsync(u => u.Cname == CName);
        }

        public async Task<Customer?> UpdateAsync(int id, CreateCustomerRequestDto customerDto)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.Cname = customerDto.CName;
            existingCustomer.Cmail = customerDto.Cmail;
            existingCustomer.Cphone = customerDto.CPhone;
            existingCustomer.Cimage = customerDto.CImage;
            existingCustomer.Clocation = customerDto.CLocation;
            existingCustomer.Cstatu = customerDto.CStatu;
            existingCustomer.Cbudget = customerDto.CBudget;

            await _context.SaveChangesAsync();

            return existingCustomer;
        }

        public Task<bool> UserExistsAsync(int id)
        {
            return _context.Customers.AnyAsync(s => s.Id == id);
        }
    }
}
