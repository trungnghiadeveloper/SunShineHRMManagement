using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Loaitk
{
    public int Id { get; set; }

    public string? TenLoai { get; set; }

    public virtual ICollection<Taikhoan> Taikhoans { get; } = new List<Taikhoan>();
}
