using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Hopdong
{
    public int Id { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? NoiDung { get; set; }

    public string? ThoiHan { get; set; }

    public string? TrangThai { get; set; }

    public string? Idnv { get; set; }

    public int? IdloaiHopDong { get; set; }

    public virtual Loaihd? IdloaiHopDongNavigation { get; set; }

    public virtual Nhanvien? IdnvNavigation { get; set; }
}
