using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Nhanvien
{
    public string Id { get; set; } = null!;

    public string? HoDem { get; set; }

    public string? Ten { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? Cccd { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? QueQuan { get; set; }

    public DateTime? NgayTuyenDung { get; set; }

    public byte[]? AnhProfile { get; set; }

    public int? IdviTri { get; set; }

    public int? IdchucVu { get; set; }

    public int? IdphongBan { get; set; }

    public virtual ICollection<Bangcap> Bangcaps { get; } = new List<Bangcap>();

    public virtual ICollection<Baohiem> Baohiems { get; } = new List<Baohiem>();

    public virtual ICollection<Chamcong> Chamcongs { get; } = new List<Chamcong>();

    public virtual ICollection<Daotaonhanvien> Daotaonhanviens { get; } = new List<Daotaonhanvien>();

    public virtual ICollection<Hopdong> Hopdongs { get; } = new List<Hopdong>();

    public virtual Chucvu? IdchucVuNavigation { get; set; }

    public virtual Phongban? IdphongBanNavigation { get; set; }

    public virtual Vitricv? IdviTriNavigation { get; set; }

    public virtual ICollection<Luong> Luongs { get; } = new List<Luong>();

    public virtual ICollection<Taikhoan> Taikhoans { get; } = new List<Taikhoan>();

    public virtual ICollection<Tknganhang> Tknganhangs { get; } = new List<Tknganhang>();

    public virtual ICollection<Yeucaunghiphep> Yeucaunghipheps { get; } = new List<Yeucaunghiphep>();
}
