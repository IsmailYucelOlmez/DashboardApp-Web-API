using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashboardApp.Models;
using DashboardApp.Mappers;
using System.Collections;
using DashboardApp.DTO.User;
using DashboardApp.Interfaces;
using DashboardApp.Helpers;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DashboardDbContext _context;

        private readonly IUserRepository _userRepository;

        public UsersController(DashboardDbContext context, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] QueryObject query)
        {
            var users= await _userRepository.GetAllAsync(query);

            var userdto=users.Select(s => s.ToUserDto()).ToList();

            return Ok(userdto);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UpdateUserRequestDto updateDto)
        {
            var userModel = await _userRepository.UpdateAsync(id,updateDto);

            if (userModel == null)
            {
                return NotFound();
            }
            

            return Ok(userModel.ToUserDto());
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDto();

            await _userRepository.CreateAsync(userModel);

            return CreatedAtAction("GetUser", new { id = userModel.Id }, userModel.ToUserDto());
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            

            return NoContent();
        }

        //private async Task<bool> UserExists(int id)
        //{
        //    var exist=await _userRepository.UserExistsAsync(id);
        //    return exist;
        //}
    }
}
