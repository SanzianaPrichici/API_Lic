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
    public class RezervaresController : ControllerBase
    {
        private readonly API_LicContext _context;

        public RezervaresController(API_LicContext context)
        {
            _context = context;
        }

        // GET: api/Rezervares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rezervare>>> GetRezervare()
        {
            return await _context.Rezervare.ToListAsync();
        }

        // GET: api/Rezervares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rezervare>> GetRezervare(int id)
        {
            var rezervare = await _context.Rezervare.FindAsync(id);

            if (rezervare == null)
            {
                return NotFound();
            }

            return rezervare;
        }

        // PUT: api/Rezervares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRezervare(int id, Rezervare rezervare)
        {
            if (id != rezervare.ID)
            {
                return BadRequest();
            }

            _context.Entry(rezervare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervareExists(id))
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

        // POST: api/Rezervares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rezervare>> PostRezervare(Rezervare rezervare)
        {
            _context.Rezervare.Add(rezervare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRezervare", new { id = rezervare.ID }, rezervare);
        }

        // DELETE: api/Rezervares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRezervare(int id)
        {
            var rezervare = await _context.Rezervare.FindAsync(id);
            if (rezervare == null)
            {
                return NotFound();
            }

            _context.Rezervare.Remove(rezervare);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RezervareExists(int id)
        {
            return _context.Rezervare.Any(e => e.ID == id);
        }
    }
}
