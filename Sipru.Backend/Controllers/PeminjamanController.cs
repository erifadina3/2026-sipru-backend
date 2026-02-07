using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sipru.Backend.Data;
using Sipru.Backend.Models;

namespace Sipru.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeminjamanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeminjamanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/peminjaman
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Peminjaman.ToListAsync();
            return Ok(data);
        }

        // GET: api/peminjaman/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _context.Peminjaman.FindAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // POST: api/peminjaman
        [HttpPost]
        public async Task<IActionResult> Create(Peminjaman peminjaman)
        {
            _context.Peminjaman.Add(peminjaman);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = peminjaman.Id }, peminjaman);
        }

        // PUT: api/peminjaman/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Peminjaman peminjaman)
        {
            if (id != peminjaman.Id)
                return BadRequest();

            _context.Entry(peminjaman).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/peminjaman/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Peminjaman.FindAsync(id);
            if (data == null)
                return NotFound();

            _context.Peminjaman.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
