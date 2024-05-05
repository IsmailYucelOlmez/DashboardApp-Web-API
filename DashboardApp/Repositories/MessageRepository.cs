using DashboardApp.DTO.Messages;
using DashboardApp.DTO.User;
using DashboardApp.Helpers;
using DashboardApp.Interfaces;
using DashboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DashboardDbContext _context;

        public MessageRepository(DashboardDbContext context)
        {
            _context = context;
        }
        public async Task<Message> CreateAsync(Message messageModel)
        {
            await _context.Messages.AddAsync(messageModel);
            await _context.SaveChangesAsync();
            return messageModel;
        }

        public async Task<Message?> DeleteAsync(int id)
        {
            var messageModel = await _context.Messages.FirstOrDefaultAsync(u => u.Id == id);

            if (messageModel == null)
            {
                return null;
            }

            _context.Messages.Remove(messageModel);
            await _context.SaveChangesAsync();
            return messageModel;
        }

        public async Task<List<Message>> GetAllAsync(MessageQueryObject query)
        {
            var messages = _context.Messages.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.MessageTitle))
            {
                messages = messages.Where(s => s.MessageTitle.Contains(query.MessageTitle));
            }

            if (query.ReceiverId!=0)
            {
                messages = messages.Where(s => s.ReceiverId==query.ReceiverId);
            }


            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await messages.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Message?> GetByIdAsync(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Message?> GetByMessageTitleAsync(string messageTitle)
        {
            return await _context.Messages.FirstOrDefaultAsync(u => u.MessageTitle == messageTitle);
        }

        public Task<bool> MessageExistsAsync(int id)
        {
            return _context.Messages.AnyAsync(s => s.Id == id);
        }

        public async Task<Message?> UpdateAsync(int id, CreateMessageRequestDto messageDto)
        {
            var existingMessage = await _context.Messages.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMessage == null)
            {
                return null;
            }

            existingMessage.MessageTitle = messageDto.MessageTitle;
            existingMessage.MessageText = messageDto.MessageText;
            existingMessage.ReceiverId = messageDto.ReceiverId;
            existingMessage.SenderId = messageDto.SenderId;
            

            await _context.SaveChangesAsync();

            return existingMessage;
        }
    }
}
