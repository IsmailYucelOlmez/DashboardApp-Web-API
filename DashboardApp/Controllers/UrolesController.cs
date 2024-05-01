using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashboardApp.Models;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrolesController : ControllerBase
    {
        private readonly DashboardDbContext _context;

        public UrolesController(DashboardDbContext context)
        {
            _context = context;
        }

        // GET: api/Uroles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urole>>> GetUroles()
        {
            return await _context.Uroles.ToListAsync();
        }

        // GET: api/Uroles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Urole>> GetUrole(int id)
        {
            var urole = await _context.Uroles.FindAsync(id);

            if (urole == null)
            {
                return NotFound();
            }

            return urole;
        }

        // PUT: api/Uroles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrole(int id, Urole urole)
        {
            if (id != urole.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(urole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UroleExists(id))
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

        // POST: api/Uroles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Urole>> PostUrole(Urole urole)
        {
            _context.Uroles.Add(urole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUrole", new { id = urole.RoleId }, urole);
        }

        // DELETE: api/Uroles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrole(int id)
        {
            var urole = await _context.Uroles.FindAsync(id);
            if (urole == null)
            {
                return NotFound();
            }

            _context.Uroles.Remove(urole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UroleExists(int id)
        {
            return _context.Uroles.Any(e => e.RoleId == id);
        }
    }
}
