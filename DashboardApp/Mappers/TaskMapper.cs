using DashboardApp.DTO.Task;
using DashboardApp.DTO.User;
using DashboardApp.Models;
using DashboardTask = DashboardApp.Models.Task;

namespace DashboardApp.Mappers
{
    public static class TaskMapper
    {
        public static TaskDto ToUserDto(this DashboardTask taskModel)
        {
            return new TaskDto
            {
                Id = taskModel.Id,
                TaskTitle = taskModel.TaskTitle,
                TaskText = taskModel.TaskText,
                AssignedUserId = taskModel.AssignedUserId,
                
            };
        }

        public static DashboardTask ToUserFromCreateDto(this CreateTaskRequestDto taskDto)
        {
            return new DashboardTask
            {
                TaskTitle = taskDto.TaskTitle,
                TaskText = taskDto.TaskText,
                AssignedUserId = taskDto.AssignedUserId,
                
            };
        }
    }
}
