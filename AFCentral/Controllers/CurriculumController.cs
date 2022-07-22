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
    public class CurriculumController : ControllerBase
    {
        private readonly CurriculumContext _context;

        public CurriculumController(CurriculumContext context)
        {
            _context = context;
        }

        // GET: api/Curriculum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curriculum>>> GetCurriculums()
        {
          if (_context.Curriculums == null)
          {
              return NotFound();
          }
            return await _context.Curriculums.ToListAsync();
        }

        // GET: api/Curriculum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curriculum>> GetCurriculum(string id)
        {
          if (_context.Curriculums == null)
          {
              return NotFound();
          }
            var curriculum = await _context.Curriculums.FindAsync(id);

            if (curriculum == null)
            {
                return NotFound();
            }

            return curriculum;
        }

        // PUT: api/Curriculum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurriculum(string id, Curriculum curriculum)
        {
            if (id != curriculum.CurriculumId)
            {
                return BadRequest();
            }

            _context.Entry(curriculum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurriculumExists(id))
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

        // POST: api/Curriculum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curriculum>> PostCurriculum(Curriculum curriculum)
        {
          if (_context.Curriculums == null)
          {
              return Problem("Entity set 'CurriculumContext.Curriculums'  is null.");
          }
            _context.Curriculums.Add(curriculum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CurriculumExists(curriculum.CurriculumId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCurriculum", new { id = curriculum.CurriculumId }, curriculum);
        }

        // DELETE: api/Curriculum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurriculum(string id)
        {
            if (_context.Curriculums == null)
            {
                return NotFound();
            }
            var curriculum = await _context.Curriculums.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }

            _context.Curriculums.Remove(curriculum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurriculumExists(string id)
        {
            return (_context.Curriculums?.Any(e => e.CurriculumId == id)).GetValueOrDefault();
        }
    }
}
