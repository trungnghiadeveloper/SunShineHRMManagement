using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Luong
{
    public int Id { get; set; }

    public double? ThanhTien { get; set; }

    public string? DonVi { get; set; }

    public string Idnv { get; set; } = null!;

    public virtual Nhanvien IdnvNavigation { get; set; } = null!;
}
