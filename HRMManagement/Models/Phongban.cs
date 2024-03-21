using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Phongban
{
    public int Id { get; set; }

    public string? TenPhongBan { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? MoTa { get; set; }

    public string? IdnvquanLy { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; } = new List<Nhanvien>();

    public virtual ICollection<Vitricv> Vitricvs { get; } = new List<Vitricv>();
}
