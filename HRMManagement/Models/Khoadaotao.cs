using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Khoadaotao
{
    public int Id { get; set; }

    public string? TenKhoa { get; set; }

    public string? MoTa { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? NguoiHuongDan { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<Daotaonhanvien> Daotaonhanviens { get; } = new List<Daotaonhanvien>();
}
