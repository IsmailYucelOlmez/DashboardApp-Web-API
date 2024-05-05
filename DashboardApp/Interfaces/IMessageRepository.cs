using DashboardApp.DTO.Messages;
using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Models;

namespace DashboardApp.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllAsync(MessageQueryObject query);
        Task<Message?> GetByIdAsync(int id);
        Task<Message?> GetByMessageTitleAsync(string symbol);
        Task<Message> CreateAsync(Message messageModel);
        Task<Message?> UpdateAsync(int id, CreateMessageRequestDto messageDto);
        Task<Message?> DeleteAsync(int id);
        Task<bool> MessageExistsAsync(int id);
    }
}
