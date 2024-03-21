using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Ungvien
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

    public DateTime? NgayUngTuyen { get; set; }

    public string? LinkHoSo { get; set; }

    public virtual ICollection<Phongvan> Phongvans { get; } = new List<Phongvan>();

    public virtual ICollection<Tuyendung> Tuyendungs { get; } = new List<Tuyendung>();
}
