using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRMManagement.Models;

public partial class HrmContext : DbContext
{
    public HrmContext()
    {
    }

    public HrmContext(DbContextOptions<HrmContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Bangcap> Bangcaps { get; set; }

    public virtual DbSet<Baohiem> Baohiems { get; set; }

    public virtual DbSet<Chamcong> Chamcongs { get; set; }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    public virtual DbSet<Daotaonhanvien> Daotaonhanviens { get; set; }

    public virtual DbSet<Hopdong> Hopdongs { get; set; }

    public virtual DbSet<Khoadaotao> Khoadaotaos { get; set; }

    public virtual DbSet<Loaibh> Loaibhs { get; set; }

    public virtual DbSet<Loaihd> Loaihds { get; set; }

    public virtual DbSet<Loaitk> Loaitks { get; set; }

    public virtual DbSet<Luong> Luongs { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phongban> Phongbans { get; set; }

    public virtual DbSet<Phongvan> Phongvans { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Tknganhang> Tknganhangs { get; set; }

    public virtual DbSet<Tuyendung> Tuyendungs { get; set; }

    public virtual DbSet<Ungvien> Ungviens { get; set; }

    public virtual DbSet<Vitricv> Vitricvs { get; set; }

    public virtual DbSet<Yeucaunghiphep> Yeucaunghipheps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bangcap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BANGCAP__3214EC272C4DF4C2");

            entity.ToTable("BANGCAP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChuyenNganh).HasMaxLength(50);
            entity.Property(e => e.Idnv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDNV");
            entity.Property(e => e.Ngay).HasColumnType("date");
            entity.Property(e => e.NoiCap).HasMaxLength(300);
            entity.Property(e => e.TenBang).HasMaxLength(50);

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Bangcaps)
                .HasForeignKey(d => d.Idnv)
                .HasConstraintName("FK__BANGCAP__IDNV__0FEC5ADD");
        });

        modelBuilder.Entity<Baohiem>(entity =>
        {
            entity.HasKey(e => e.IdsoBaoHiem).HasName("PK__BAOHIEM__767AAC3D4769D873");

            entity.ToTable("BAOHIEM");

            entity.Property(e => e.IdsoBaoHiem).HasColumnName("IDSoBaoHiem");
            entity.Property(e => e.Idloai).HasColumnName("IDLoai");
            entity.Property(e => e.Idnv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDNV");
            entity.Property(e => e.NgayHienHanh).HasColumnType("date");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdloaiNavigation).WithMany(p => p.Baohiems)
                .HasForeignKey(d => d.Idloai)
                .HasConstraintName("FK__BAOHIEM__IDLoai__1A69E950");

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Baohiems)
                .HasForeignKey(d => d.Idnv)
                .HasConstraintName("FK__BAOHIEM__IDNV__1B5E0D89");
        });

        modelBuilder.Entity<Chamcong>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Idnv }).HasName("PK__CHAMCONG__099330BC029EF5FB");

            entity.ToTable("CHAMCONG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idnv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDNV");
            entity.Property(e => e.ThoiGian).HasColumnType("date");

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Chamcongs)
                .HasForeignKey(d => d.Idnv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHAMCONG__IDNV__1E3A7A34");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CHUCVU__3214EC2765745288");

            entity.ToTable("CHUCVU");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenChucVu).HasMaxLength(50);
        });

        modelBuilder.Entity<Daotaonhanvien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DAOTAONH__3214EC27F7476E72");

            entity.ToTable("DAOTAONHANVIEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idkhoadt).HasColumnName("IDKHOADT");
            entity.Property(e => e.Idnv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDNV");
            entity.Property(e => e.NgayHoanThanh).HasColumnType("date");

            entity.HasOne(d => d.IdkhoadtNavigation).WithMany(p => p.Daotaonhanviens)
                .HasForeignKey(d => d.Idkhoadt)
                .HasConstraintName("FK__DAOTAONHA__IDKHO__23F3538A");

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Daotaonhanviens)
                .HasForeignKey(d => d.Idnv)
                .HasConstraintName("FK__DAOTAONHAN__IDNV__22FF2F51");
        });

        modelBuilder.Entity<Hopdong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HOPDONG__3214EC27DCB801CC");

            entity.ToTable("HOPDONG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdloaiHopDong).HasColumnName("IDLoaiHopDong");
            entity.Property(e => e.Idnv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDNV");
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.NoiDung).HasMaxLength(1000);
            entity.Property(e => e.ThoiHan).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdloaiHopDongNavigation).WithMany(p => p.Hopdongs)
                .HasForeignKey(d => d.IdloaiHopDong)
                .HasConstraintName("FK__HOPDONG__IDLoaiH__15A53433");

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Hopdongs)
                .HasForeignKey(d => d.Idnv)
                .HasConstraintName("FK__HOPDONG__IDNV__14B10FFA");
        });

        modelBuilder.Entity<Khoadaotao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KHOADAOT__3214EC27EBE21137");

            entity.ToTable("KHOADAOTAO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(300);
            entity.Property(e => e.MoTa).HasMaxLength(1000);
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.NguoiHuongDan).HasMaxLength(50);
            entity.Property(e => e.TenKhoa).HasMaxLength(50);
        });

        modelBuilder.Entity<Loaibh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOAIBH__3214EC2705327872");

            entity.ToTable("LOAIBH");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Loaihd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOAIHD__3214EC27593AA4CE");

            entity.ToTable("LOAIHD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Loaitk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOAITK__3214EC27E2BF82AF");

            entity.ToTable("LOAITK");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Idnv }).HasName("PK__LUONG__099330BC17F8030D");

            entity.ToTable("LUONG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idnv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDNV");
            entity.Property(e => e.DonVi)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.Idnv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LUONG__IDNV__2C88998B");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NHANVIEN__3214EC27A56E0296");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.AnhProfile).HasColumnType("image");
            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(300);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoDem).HasMaxLength(30);
            entity.Property(e => e.IdchucVu).HasColumnName("IDChucVu");
            entity.Property(e => e.IdphongBan).HasColumnName("IDPhongBan");
            entity.Property(e => e.IdviTri).HasColumnName("IDViTri");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.NgayTuyenDung).HasColumnType("date");
            entity.Property(e => e.QueQuan).HasMaxLength(300);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(20);

            entity.HasOne(d => d.IdchucVuNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.IdchucVu)
                .HasConstraintName("FK__NHANVIEN__IDChuc__038683F8");

            entity.HasOne(d => d.IdphongBanNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.IdphongBan)
                .HasConstraintName("FK__NHANVIEN__IDPhon__047AA831");

            entity.HasOne(d => d.IdviTriNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.IdviTri)
                .HasConstraintName("FK__NHANVIEN__IDViTr__02925FBF");
        });

        modelBuilder.Entity<Phongban>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHONGBAN__3214EC27996446DE");

            entity.ToTable("PHONGBAN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(300);
            entity.Property(e => e.IdnvquanLy)
                .HasMaxLength(10)
                .HasColumnName("IDNVQuanLy");
            entity.Property(e => e.MoTa).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenPhongBan).HasMaxLength(50);
        });

        modelBuilder.Entity<Phongvan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHONGVAN__3214EC273DDB7108");

            entity.ToTable("PHONGVAN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GhiChu).HasMaxLength(400);
            entity.Property(e => e.IdungVien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDUngVien");
            entity.Property(e => e.KetQua).HasMaxLength(50);
            entity.Property(e => e.NgayPhongVan).HasColumnType("date");
            entity.Property(e => e.NguoiPhongVan)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdungVienNavigation).WithMany(p => p.Phongvans)
                .HasForeignKey(d => d.IdungVien)
                .HasConstraintName("FK__PHONGVAN__IDUngV__324172E1");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TAIKHOAN__3214EC27516F3B84");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idloai).HasColumnName("IDLoai");
            entity.Property(e => e.Idnv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDNV");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdloaiNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.Idloai)
                .HasConstraintName("FK__TAIKHOAN__IDLoai__093F5D4E");

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.Idnv)
                .HasConstraintName("FK__TAIKHOAN__IDNV__0A338187");
        });

        modelBuilder.Entity<Tknganhang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TKNGANHA__3214EC27E943A94D");

            entity.ToTable("TKNGANHANG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idnv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDNV");
            entity.Property(e => e.SoTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SoThe)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenNganHang).HasMaxLength(50);

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Tknganhangs)
                .HasForeignKey(d => d.Idnv)
                .HasConstraintName("FK__TKNGANHANG__IDNV__0D0FEE32");
        });

        modelBuilder.Entity<Tuyendung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TUYENDUN__3214EC277DC77113");

            entity.ToTable("TUYENDUNG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdungVien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDUngVien");
            entity.Property(e => e.IdviTri).HasColumnName("IDViTri");
            entity.Property(e => e.NgayDeNghi).HasColumnType("date");
            entity.Property(e => e.ThongTinChiTiet).HasMaxLength(1000);

            entity.HasOne(d => d.IdungVienNavigation).WithMany(p => p.Tuyendungs)
                .HasForeignKey(d => d.IdungVien)
                .HasConstraintName("FK__TUYENDUNG__IDUng__29AC2CE0");

            entity.HasOne(d => d.IdviTriNavigation).WithMany(p => p.Tuyendungs)
                .HasForeignKey(d => d.IdviTri)
                .HasConstraintName("FK__TUYENDUNG__IDViT__28B808A7");
        });

        modelBuilder.Entity<Ungvien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UNGVIEN__3214EC27E8521061");

            entity.ToTable("UNGVIEN");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(300);
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.HoDem).HasMaxLength(30);
            entity.Property(e => e.LinkHoSo).HasMaxLength(300);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.NgayUngTuyen).HasColumnType("date");
            entity.Property(e => e.QueQuan).HasMaxLength(300);
            entity.Property(e => e.Sdt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(20);
        });

        modelBuilder.Entity<Vitricv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VITRICV__3214EC27A1644A97");

            entity.ToTable("VITRICV");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HetHan).HasColumnType("date");
            entity.Property(e => e.IdphongBan).HasColumnName("IDPhongBan");
            entity.Property(e => e.MoTaCv)
                .HasMaxLength(100)
                .HasColumnName("MoTaCV");
            entity.Property(e => e.NgayDang).HasColumnType("date");
            entity.Property(e => e.TenVitri).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdphongBanNavigation).WithMany(p => p.Vitricvs)
                .HasForeignKey(d => d.IdphongBan)
                .HasConstraintName("FK__VITRICV__IDPhong__7DCDAAA2");
        });

        modelBuilder.Entity<Yeucaunghiphep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__YEUCAUNG__3214EC272656D7D3");

            entity.ToTable("YEUCAUNGHIPHEP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idnv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDNV");
            entity.Property(e => e.LoaiNghiPhep).HasMaxLength(100);
            entity.Property(e => e.LyDo).HasMaxLength(400);
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Yeucaunghipheps)
                .HasForeignKey(d => d.Idnv)
                .HasConstraintName("FK__YEUCAUNGHI__IDNV__2F650636");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
}
