using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Phongvan
{
    public int Id { get; set; }

    public DateTime? NgayPhongVan { get; set; }

    public string? NguoiPhongVan { get; set; }

    public string? GhiChu { get; set; }

    public string? IdungVien { get; set; }

    public string? KetQua { get; set; }

    public virtual Ungvien? IdungVienNavigation { get; set; }
}
