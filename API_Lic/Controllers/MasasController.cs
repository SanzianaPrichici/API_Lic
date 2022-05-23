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
    public class MasasController : ControllerBase
    {
        private readonly API_LicContext _context;

        public MasasController(API_LicContext context)
        {
            _context = context;
        }

        // GET: api/Masas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masa>>> GetMasa()
        {
            return await _context.Masa.ToListAsync();
        }

        // GET: api/Masas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Masa>> GetMasa(int id)
        {
            var masa = await _context.Masa.FindAsync(id);

            if (masa == null)
            {
                return NotFound();
            }

            return masa;
        }

        // PUT: api/Masas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasa(int id, Masa masa)
        {
            if (id != masa.ID)
            {
                return BadRequest();
            }

            _context.Entry(masa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasaExists(id))
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

        // POST: api/Masas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Masa>> PostMasa(Masa masa)
        {
            _context.Masa.Add(masa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasa", new { id = masa.ID }, masa);
        }

        // DELETE: api/Masas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasa(int id)
        {
            var masa = await _context.Masa.FindAsync(id);
            if (masa == null)
            {
                return NotFound();
            }

            _context.Masa.Remove(masa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasaExists(int id)
        {
            return _context.Masa.Any(e => e.ID == id);
        }
    }
}
