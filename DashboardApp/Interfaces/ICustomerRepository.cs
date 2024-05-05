using DashboardApp.DTO.Customer;
using DashboardApp.Helpers;
using DashboardApp.Models;

namespace DashboardApp.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(CustomerQueryObject query);
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer?> GetByCustomerNameAsync(string symbol);
        Task<Customer> CreateAsync(Customer customerModel);
        Task<Customer?> UpdateAsync(int id, CreateCustomerRequestDto customerDto);
        Task<Customer?> DeleteAsync(int id);
        Task<bool> UserExistsAsync(int id);
    }
}
