using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Tuyendung
{
    public int Id { get; set; }

    public DateTime? NgayDeNghi { get; set; }

    public string? ThongTinChiTiet { get; set; }

    public int? IdviTri { get; set; }

    public string? IdungVien { get; set; }

    public virtual Ungvien? IdungVienNavigation { get; set; }

    public virtual Vitricv? IdviTriNavigation { get; set; }
}
