using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Lic.Data;
using API_Lic.Models;

namespace API_Lic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FelsController : ControllerBase
    {
        private readonly API_LicContext _context;

        public FelsController(API_LicContext context)
        {
            _context = context;
        }

        // GET: api/Fels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fel>>> GetFel()
        {
            return await _context.Fel.ToListAsync();
        }

        // GET: api/Fels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fel>> GetFel(int id)
        {
            var fel = await _context.Fel.FindAsync(id);

            if (fel == null)
            {
                return NotFound();
            }

            return fel;
        }

        // PUT: api/Fels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFel(int id, Fel fel)
        {
            if (id != fel.ID)
            {
                return BadRequest();
            }

            _context.Entry(fel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FelExists(id))
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

        // POST: api/Fels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fel>> PostFel(Fel fel)
        {
            _context.Fel.Add(fel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFel", new { id = fel.ID }, fel);
        }

        // DELETE: api/Fels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFel(int id)
        {
            var fel = await _context.Fel.FindAsync(id);
            if (fel == null)
            {
                return NotFound();
            }

            _context.Fel.Remove(fel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FelExists(int id)
        {
            return _context.Fel.Any(e => e.ID == id);
        }
    }
}
