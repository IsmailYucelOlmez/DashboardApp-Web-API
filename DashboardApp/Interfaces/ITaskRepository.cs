using DashboardApp.DTO.Task;
using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Models;
using DashboardTask = DashboardApp.Models.Task;

namespace DashboardApp.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<DashboardTask>> GetAllAsync(TaskQueryObject query);
        Task<DashboardTask?> GetByIdAsync(int id);
        Task<DashboardTask?> GetByTaskTitleAsync(string symbol);
        Task<DashboardTask> CreateAsync(DashboardTask taskModel);
        Task<DashboardTask?> UpdateAsync(int id, CreateTaskRequestDto taskDto);
        Task<DashboardTask?> DeleteAsync(int id);
        Task<bool> UserExistsAsync(int id);
    }
}
