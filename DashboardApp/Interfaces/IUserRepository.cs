using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Models;

namespace DashboardApp.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(QueryObject query);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUserNameAsync(string symbol);
        Task<User> CreateAsync(User stockModel);
        Task<User?> UpdateAsync(int id, UpdateUserRequestDto stockDto);
        Task<User?> DeleteAsync(int id);
        Task<bool> UserExistsAsync(int id);
    }

}
