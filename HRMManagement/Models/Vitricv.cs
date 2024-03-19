using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Vitricv
{
    public int Id { get; set; }

    public string? TenVitri { get; set; }

    public string? MoTaCv { get; set; }

    public double? MucLuongCoBan { get; set; }

    public DateTime? NgayDang { get; set; }

    public DateTime? HetHan { get; set; }

    public string? TrangThai { get; set; }

    public int? IdphongBan { get; set; }

    public virtual Phongban? IdphongBanNavigation { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; } = new List<Nhanvien>();

    public virtual ICollection<Tuyendung> Tuyendungs { get; } = new List<Tuyendung>();
}
