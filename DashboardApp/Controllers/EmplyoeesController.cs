using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashboardApp.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using DashboardApp.Helpers;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmplyoeesController : ControllerBase
    {
        private readonly DashboardDbContext _context;

        public EmplyoeesController(DashboardDbContext context)
        {
            _context = context;
        }

        // GET: api/Emplyoees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emplyoee>>> GetEmplyoees()
        {

            return await _context.Emplyoees.ToListAsync();
        }

        // GET: api/Emplyoees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emplyoee>> GetEmplyoee(int id)
        {
            var emplyoee = await _context.Emplyoees.FindAsync(id);

            if (emplyoee == null)
            {
                return NotFound();
            }

            return emplyoee;
        }

        // PUT: api/Emplyoees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmplyoee(int id, Emplyoee emplyoee)
        {
            if (id != emplyoee.Id)
            {
                return BadRequest();
            }

            _context.Entry(emplyoee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmplyoeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Emplyoees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emplyoee>> PostEmplyoee(Emplyoee emplyoee)
        {
            _context.Emplyoees.Add(emplyoee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmplyoee", new { id = emplyoee.Id }, emplyoee);
        }

        // DELETE: api/Emplyoees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmplyoee(int id)
        {
            var emplyoee = await _context.Emplyoees.FindAsync(id);
            if (emplyoee == null)
            {
                return NotFound();
            }

            _context.Emplyoees.Remove(emplyoee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmplyoeeExists(int id)
        {
            return _context.Emplyoees.Any(e => e.Id == id);
        }
    }
}
