using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Chucvu
{
    public int Id { get; set; }

    public string? TenChucVu { get; set; }

    public double? PhuCapChucVu { get; set; }

    public double? HeSoLuong { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; } = new List<Nhanvien>();
}
