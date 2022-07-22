using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AFCentral.Models;

namespace AFCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammesController : ControllerBase
    {
        private readonly ProgrammeContext _context;

        public ProgrammesController(ProgrammeContext context)
        {
            _context = context;
        }

        // GET: api/Programmes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programme>>> GetProgrammes()
        {
          if (_context.Programmes == null)
          {
              return NotFound();
          }
            return await _context.Programmes.ToListAsync();
        }

        // GET: api/Programmes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Programme>> GetProgramme(string id)
        {
          if (_context.Programmes == null)
          {
              return NotFound();
          }
            var programme = await _context.Programmes.FindAsync(id);

            if (programme == null)
            {
                return NotFound();
            }

            return programme;
        }

        // PUT: api/Programmes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramme(string id, Programme programme)
        {
            if (id != programme.ProgrammeId)
            {
                return BadRequest();
            }

            _context.Entry(programme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammeExists(id))
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

        // POST: api/Programmes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Programme>> PostProgramme(Programme programme)
        {
          if (_context.Programmes == null)
          {
              return Problem("Entity set 'ProgrammeContext.Programmes'  is null.");
          }
            _context.Programmes.Add(programme);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProgrammeExists(programme.ProgrammeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProgramme", new { id = programme.ProgrammeId }, programme);
        }

        // DELETE: api/Programmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramme(string id)
        {
            if (_context.Programmes == null)
            {
                return NotFound();
            }
            var programme = await _context.Programmes.FindAsync(id);
            if (programme == null)
            {
                return NotFound();
            }

            _context.Programmes.Remove(programme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgrammeExists(string id)
        {
            return (_context.Programmes?.Any(e => e.ProgrammeId == id)).GetValueOrDefault();
        }
    }
}
