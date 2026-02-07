using Microsoft.EntityFrameworkCore;
using Sipru.Backend.Models;

namespace Sipru.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Peminjaman> Peminjaman { get; set; }
    }
}
