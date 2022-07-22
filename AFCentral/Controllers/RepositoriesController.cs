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
    public class RepositoriesController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public RepositoriesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Repositories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repositories>>> GetRepositories()
        {
          if (_context.Repositories == null)
          {
              return NotFound();
          }
            return await _context.Repositories.ToListAsync();
        }

        // GET: api/Repositories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repositories>> GetRepositories(string id)
        {
          if (_context.Repositories == null)
          {
              return NotFound();
          }
            var repositories = await _context.Repositories.FindAsync(id);

            if (repositories == null)
            {
                return NotFound();
            }

            return repositories;
        }

        // PUT: api/Repositories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepositories(string id, Repositories repositories)
        {
            if (id != repositories.RepositoryId)
            {
                return BadRequest();
            }

            _context.Entry(repositories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepositoriesExists(id))
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

        // POST: api/Repositories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Repositories>> PostRepositories(Repositories repositories)
        {
          if (_context.Repositories == null)
          {
              return Problem("Entity set 'RepositoryContext.Repositories'  is null.");
          }
            _context.Repositories.Add(repositories);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepositoriesExists(repositories.RepositoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRepositories", new { id = repositories.RepositoryId }, repositories);
        }

        // DELETE: api/Repositories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepositories(string id)
        {
            if (_context.Repositories == null)
            {
                return NotFound();
            }
            var repositories = await _context.Repositories.FindAsync(id);
            if (repositories == null)
            {
                return NotFound();
            }

            _context.Repositories.Remove(repositories);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepositoriesExists(string id)
        {
            return (_context.Repositories?.Any(e => e.RepositoryId == id)).GetValueOrDefault();
        }
    }
}
