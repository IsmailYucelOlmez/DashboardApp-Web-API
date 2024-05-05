using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashboardApp.Models;
using DashboardApp.Interfaces;
using DashboardApp.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using DashboardApp.Helpers;
using DashboardApp.Mappers;
using DashboardApp.DTO.Messages;
using DashboardApp.DTO.User;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DashboardDbContext _context;

        private readonly IMessageRepository _messageRepository;

        public MessagesController(DashboardDbContext context, IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages([FromQuery] MessageQueryObject query)
        {
            var messages = await _messageRepository.GetAllAsync(query);

            var messagedto = messages.Select(s => s.ToMessageDto()).ToList();

            return Ok(messagedto);
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message.ToMessageDto());
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, CreateMessageRequestDto messageDto)
        {
            var messageModel = await _messageRepository.UpdateAsync(id, messageDto);

            if (messageModel == null)
            {
                return NotFound();
            }


            return Ok(messageModel.ToMessageDto());
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage([FromBody] CreateMessageRequestDto messageDto)
        {
            var messageModel = messageDto.ToMessageFromCreateDto();

            await _messageRepository.CreateAsync(messageModel);

            return CreatedAtAction("GetMessage", new { id = messageModel.Id }, messageModel.ToMessageDto());
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _messageRepository.DeleteAsync(id);
            if (message == null)
            {
                return NotFound();
            }


            return NoContent();
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
