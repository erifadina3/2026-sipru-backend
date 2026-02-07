using System.ComponentModel.DataAnnotations;

namespace Sipru.Backend.Models
{
    public class Peminjaman
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama peminjam wajib diisi")]
        [StringLength(100)]
        public string NamaPeminjam { get; set; }

        [Required(ErrorMessage = "Nama ruangan wajib diisi")]
        [StringLength(100)]
        public string NamaRuangan { get; set; }

        [Required(ErrorMessage = "Tanggal mulai wajib diisi")]
        public DateTime TanggalMulai { get; set; }

        [Required(ErrorMessage = "Tanggal selesai wajib diisi")]
        public DateTime TanggalSelesai { get; set; }

        [Required(ErrorMessage = "Keperluan wajib diisi")]
        [StringLength(255)]
        public string Keperluan { get; set; }

        public PeminjamanStatus Status { get; set; } = PeminjamanStatus.Menunggu;
    }
}
