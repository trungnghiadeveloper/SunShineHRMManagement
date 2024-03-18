using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Tknganhang
{
    public int Id { get; set; }

    public string? SoTaiKhoan { get; set; }

    public string? TenNganHang { get; set; }

    public string? SoThe { get; set; }

    public string? Idnv { get; set; }

    public virtual Nhanvien? IdnvNavigation { get; set; }
}
