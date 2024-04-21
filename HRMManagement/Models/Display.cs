using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace HRMManagement.Models
{
    public class Display
    {
        public string Id { get; set; } = null!;

        public string? HoDem { get; set; }

        public string? Ten { get; set; }

        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        public string? Cccd { get; set; }

        public string? DiaChi { get; set; }

        public string? Sdt { get; set; }

        public string? Email { get; set; }

        public string? QueQuan { get; set; }

        public int? IdviTri { get; set; }

        public int? IdchucVu { get; set; }

        public int? IdphongBan { get; set; }

        public string? TenVitri { get; set; }

        public string? TenChucVu { get; set; }

        public string? TenPhongBan { get; set; }

        public string? AnhProfile { get; set; }

    }

    
}
