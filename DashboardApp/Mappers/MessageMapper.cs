using DashboardApp.DTO.Messages;
using DashboardApp.DTO.User;
using DashboardApp.Models;

namespace DashboardApp.Mappers
{
    public static class MessageMapper
    {
        public static MessageDto ToMessageDto(this Message messageModel)
        {
            return new MessageDto
            {
                Id = messageModel.Id,
                MessageTitle = messageModel.MessageTitle,
                MessageText = messageModel.MessageText,
                ReceiverId = messageModel.ReceiverId,
                SenderId = messageModel.SenderId,
                

            };
        }

        public static Message ToMessageFromCreateDto(this CreateMessageRequestDto messageDto)
        {
            return new Message
            {
                MessageTitle = messageDto.MessageTitle,
                MessageText = messageDto.MessageText,
                ReceiverId = messageDto.ReceiverId,
                SenderId = messageDto.SenderId,
               
            };
        }
    }
}
