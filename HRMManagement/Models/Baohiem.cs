using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Baohiem
{
    public int IdsoBaoHiem { get; set; }

    public DateTime? NgayHienHanh { get; set; }

    public string? TrangThai { get; set; }

    public int? Idloai { get; set; }

    public string? Idnv { get; set; }

    public virtual Loaibh? IdloaiNavigation { get; set; }

    public virtual Nhanvien? IdnvNavigation { get; set; }
}
