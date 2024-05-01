using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Interfaces;
using DashboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DashboardDbContext _context;

        public UserRepository(DashboardDbContext context) 
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userModel == null)
            {
                return null;
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<User>> GetAllAsync(QueryObject query)
        {
            
            var users = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.UserName))
            {
                users = users.Where(s => s.UserName.Contains(query.UserName));
            }

            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                users = users.Where(s => s.Email.Contains(query.Email));
            }

               
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await users.Skip(skipNumber).Take(query.PageSize).ToListAsync();
            
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public Task<bool> UserExistsAsync(int id)
        {
            return _context.Users.AnyAsync(s => s.Id == id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto)
        {
            var existingStock = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStock == null)
            {
                return null;
            }

            existingStock.UserName = userDto.UserName;
            existingStock.Password = userDto.Password;
            existingStock.Email = userDto.Email;
            existingStock.Phone = userDto.Phone;
            existingStock.Uimage = userDto.Uimage;
            existingStock.RoleId = userDto.RoleId;

            await _context.SaveChangesAsync();

            return existingStock;
        }
    }
}
