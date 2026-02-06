using Microsoft.EntityFrameworkCore;

namespace Sipru.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // nanti diisi
        // public DbSet<Peminjaman> Peminjaman { get; set; }
    }
}
