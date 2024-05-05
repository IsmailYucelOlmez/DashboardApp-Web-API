using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashboardApp.Models;
using DashboardTask = DashboardApp.Models.Task;
using DashboardApp.Interfaces;
using DashboardApp.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using DashboardApp.Helpers;
using DashboardApp.Mappers;
using DashboardApp.DTO.Task;
using DashboardApp.DTO.User;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly DashboardDbContext _context;

        private readonly ITaskRepository _taskRepository;

        public TasksController(DashboardDbContext context, ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DashboardTask>>> GetTasks([FromQuery] TaskQueryObject query)
        {
            var tasks = await _taskRepository.GetAllAsync(query);

            var taskdto = tasks.Select(s => s.ToTaskDto()).ToList();

            return Ok(taskdto);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DashboardTask>> GetTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task.ToTaskDto());
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, CreateTaskRequestDto taskdto)
        {
            var taskModel = await _taskRepository.UpdateAsync(id, taskdto);

            if (taskModel == null)
            {
                return NotFound();
            }


            return Ok(taskModel.ToTaskDto());
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DashboardTask>> PostTask([FromBody] CreateTaskRequestDto taskDto)
        {
            var taskModel = taskDto.ToTaskFromCreateDto();

            await _taskRepository.CreateAsync(taskModel);

            return CreatedAtAction("GetUser", new { id = taskModel.Id }, taskModel.ToTaskDto());
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _taskRepository.DeleteAsync(id);
            if (task == null)
            {
                return NotFound();
            }


            return NoContent();
        }

        //private bool TaskExists(int id)
        //{
        //    return _context.Tasks.Any(e => e.Id == id);
        //}
    }
}
