using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Daotaonhanvien
{
    public int Id { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    public string? Idnv { get; set; }

    public int? Idkhoadt { get; set; }

    public virtual Khoadaotao? IdkhoadtNavigation { get; set; }

    public virtual Nhanvien? IdnvNavigation { get; set; }
}
