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
    public class StakeholderItemsController : ControllerBase
    {
        private readonly StakeholderContext _context;

        public StakeholderItemsController(StakeholderContext context)
        {
            _context = context;
        }

        // GET: api/StakeholderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StakeholderItem>>> GetStakeholderItems()
        {
          if (_context.StakeholderItems == null)
          {
              return NotFound();
          }
            return await _context.StakeholderItems.ToListAsync();
        }

        // GET: api/StakeholderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StakeholderItem>> GetStakeholderItem(int id)
        {
          if (_context.StakeholderItems == null)
          {
              return NotFound();
          }
            var stakeholderItem = await _context.StakeholderItems.FindAsync(id);

            if (stakeholderItem == null)
            {
                return NotFound();
            }

            return stakeholderItem;
        }

        // PUT: api/StakeholderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStakeholderItem(string id, StakeholderItem stakeholderItem)
        {
            if (id != stakeholderItem.StakeholdersId)
            {
                return BadRequest();
            }

            _context.Entry(stakeholderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StakeholderItemExists(id))
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

        // POST: api/StakeholderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StakeholderItem>> PostStakeholderItem(StakeholderItem stakeholderItem)
        {
          if (_context.StakeholderItems == null)
          {
              return Problem("Entity set 'StakeholderContext.StakeholderItems'  is null.");
          }
            _context.StakeholderItems.Add(stakeholderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStakeholderItem", new { id = stakeholderItem.StakeholdersId }, stakeholderItem);
        }

        // DELETE: api/StakeholderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStakeholderItem(string id)
        {
            if (_context.StakeholderItems == null)
            {
                return NotFound();
            }
            var stakeholderItem = await _context.StakeholderItems.FindAsync(id);
            if (stakeholderItem == null)
            {
                return NotFound();
            }

            _context.StakeholderItems.Remove(stakeholderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StakeholderItemExists(string id)
        {
            return (_context.StakeholderItems?.Any(e => e.StakeholdersId == id)).GetValueOrDefault();
        }
    }
}
