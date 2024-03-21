using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Taikhoan
{
    public int Id { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public int? Idloai { get; set; }

    public string? Idnv { get; set; }

    public virtual Loaitk? IdloaiNavigation { get; set; }

    public virtual Nhanvien? IdnvNavigation { get; set; }
}
