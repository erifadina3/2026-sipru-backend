using System.ComponentModel.DataAnnotations;

namespace Sipru.Backend.Models
{
    public class Peminjaman
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NamaPeminjam { get; set; } = string.Empty;

        [Required]
        public string NamaRuangan { get; set; } = string.Empty;

        [Required]
        public DateTime TanggalMulai { get; set; }

        [Required]
        public DateTime TanggalSelesai { get; set; }

        public string Keperluan { get; set; } = string.Empty;

        [Required]
        public PeminjamanStatus Status { get; set; } = PeminjamanStatus.Menunggu;
    }
}
