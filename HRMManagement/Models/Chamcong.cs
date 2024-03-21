using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Chamcong
{
    public int Id { get; set; }

    public int? SoNgayLam { get; set; }

    public int? SoNgayNghi { get; set; }

    public int? SoLanTre { get; set; }

    public DateTime? ThoiGian { get; set; }

    public string Idnv { get; set; } = null!;

    public virtual Nhanvien IdnvNavigation { get; set; } = null!;
}
