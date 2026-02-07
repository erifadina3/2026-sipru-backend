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
                return NotFound(new { message = "Data peminjaman tidak ditemukan" });

            return Ok(data);
        }

        // POST: api/peminjaman
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Peminjaman peminjaman)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (peminjaman.TanggalSelesai <= peminjaman.TanggalMulai)
                return BadRequest(new { message = "Tanggal selesai harus setelah tanggal mulai" });

            peminjaman.TanggalMulai = DateTime.SpecifyKind(
                peminjaman.TanggalMulai, DateTimeKind.Utc);

            peminjaman.TanggalSelesai = DateTime.SpecifyKind(
                peminjaman.TanggalSelesai, DateTimeKind.Utc);

            _context.Peminjaman.Add(peminjaman);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = peminjaman.Id },
                peminjaman
            );
        }

        // PUT: api/peminjaman/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Peminjaman peminjaman)
        {
            if (id != peminjaman.Id)
                return BadRequest(new { message = "ID tidak cocok" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (peminjaman.TanggalSelesai <= peminjaman.TanggalMulai)
                return BadRequest(new { message = "Tanggal selesai harus setelah tanggal mulai" });

            var existing = await _context.Peminjaman.FindAsync(id);
            if (existing == null)
                return NotFound(new { message = "Data peminjaman tidak ditemukan" });

            existing.NamaPeminjam = peminjaman.NamaPeminjam;
            existing.NamaRuangan = peminjaman.NamaRuangan;
            existing.TanggalMulai = DateTime.SpecifyKind(
                peminjaman.TanggalMulai, DateTimeKind.Utc);
            existing.TanggalSelesai = DateTime.SpecifyKind(
                peminjaman.TanggalSelesai, DateTimeKind.Utc);
            existing.Keperluan = peminjaman.Keperluan;
            existing.Status = peminjaman.Status;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // DELETE: api/peminjaman/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Peminjaman.FindAsync(id);
            if (data == null)
                return NotFound(new { message = "Data peminjaman tidak ditemukan" });

            _context.Peminjaman.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
