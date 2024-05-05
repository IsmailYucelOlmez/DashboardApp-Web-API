using DashboardApp.DTO.Task;
using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Interfaces;
using DashboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DashboardDbContext _context;

        public TaskRepository(DashboardDbContext context)
        {
            _context = context;
        }
        public async Task<Models.Task> CreateAsync(Models.Task taskModel)
        {
            await _context.Tasks.AddAsync(taskModel);
            await _context.SaveChangesAsync();
            return taskModel;
        }

        public async Task<Models.Task?> DeleteAsync(int id)
        {
            var taskModel = await _context.Tasks.FirstOrDefaultAsync(u => u.Id == id);

            if (taskModel == null)
            {
                return null;
            }

            _context.Tasks.Remove(taskModel);
            await _context.SaveChangesAsync();
            return taskModel;
        }

        public async Task<List<Models.Task>> GetAllAsync(TaskQueryObject query)
        {
            var tasks = _context.Tasks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.TaskTitle))
            {
                tasks = tasks.Where(s => s.TaskTitle.Contains(query.TaskTitle));
            }

            if (query.AssignedUserId != 0)
            {
                tasks = tasks.Where(s => s.AssignedUserId==query.AssignedUserId);
            }


            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await tasks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Models.Task?> GetByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Models.Task?> GetByTaskTitleAsync(string taskTitle)
        {
            return await _context.Tasks.FirstOrDefaultAsync(u => u.TaskTitle == taskTitle);
        }

        public async Task<Models.Task?> UpdateAsync(int id, CreateTaskRequestDto taskDto)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTask == null)
            {
                return null;
            }

            existingTask.TaskTitle = taskDto.TaskTitle;
            existingTask.TaskText = taskDto.TaskText;
            existingTask.AssignedUserId = taskDto.AssignedUserId;
            

            await _context.SaveChangesAsync();

            return existingTask;
        }

        public Task<bool> UserExistsAsync(int id)
        {
            return _context.Tasks.AnyAsync(s => s.Id == id);
        }
    }
}
