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
    public class Fel_ProdController : ControllerBase
    {
        private readonly API_LicContext _context;

        public Fel_ProdController(API_LicContext context)
        {
            _context = context;
        }

        // GET: api/Fel_Prod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fel_Prod>>> GetFel_Prod()
        {
            return await _context.Fel_Prod.ToListAsync();
        }

        // GET: api/Fel_Prod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fel_Prod>> GetFel_Prod(int id)
        {
            var fel_Prod = await _context.Fel_Prod.FindAsync(id);

            if (fel_Prod == null)
            {
                return NotFound();
            }

            return fel_Prod;
        }

        // PUT: api/Fel_Prod/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFel_Prod(int id, Fel_Prod fel_Prod)
        {
            if (id != fel_Prod.ID)
            {
                return BadRequest();
            }

            _context.Entry(fel_Prod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Fel_ProdExists(id))
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

        // POST: api/Fel_Prod
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fel_Prod>> PostFel_Prod(Fel_Prod fel_Prod)
        {
            _context.Fel_Prod.Add(fel_Prod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFel_Prod", new { id = fel_Prod.ID }, fel_Prod);
        }

        // DELETE: api/Fel_Prod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFel_Prod(int id)
        {
            var fel_Prod = await _context.Fel_Prod.FindAsync(id);
            if (fel_Prod == null)
            {
                return NotFound();
            }

            _context.Fel_Prod.Remove(fel_Prod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Fel_ProdExists(int id)
        {
            return _context.Fel_Prod.Any(e => e.ID == id);
        }
    }
}
