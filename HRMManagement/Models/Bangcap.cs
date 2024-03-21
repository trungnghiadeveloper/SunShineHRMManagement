using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Bangcap
{
    public int Id { get; set; }

    public string? TenBang { get; set; }

    public string? NoiCap { get; set; }

    public string? ChuyenNganh { get; set; }

    public DateTime? Ngay { get; set; }

    public string? Idnv { get; set; }

    public virtual Nhanvien? IdnvNavigation { get; set; }
}
