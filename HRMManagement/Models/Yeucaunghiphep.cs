using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Yeucaunghiphep
{
    public int Id { get; set; }

    public string? LoaiNghiPhep { get; set; }

    public string? LyDo { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? TrangThai { get; set; }

    public string? Idnv { get; set; }

    public virtual Nhanvien? IdnvNavigation { get; set; }
}
