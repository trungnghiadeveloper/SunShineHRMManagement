namespace HRMManagement.Models
{
    public class UngVienViewModel
    {
        //Ungvien
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

        public DateTime? NgayUngTuyen { get; set; }

        public string? LinkHoSo { get; set; }

        //Phongvan
        public int IdPhongVan { get; set; }

        public DateTime? NgayPhongVan { get; set; }

        public string? NguoiPhongVan { get; set; }// IDNV
        public string? TenNguoiPhongVan { get; set; }// IDNV


        public string? GhiChu { get; set; }

        public string? KetQua { get; set; }

        //Tuyendung
        public int IdTuyenDung { get; set; }

        public DateTime? NgayDeNghi { get; set; }

        public string? ThongTinChiTiet { get; set; }


        //VitriCV
        public int? IdviTri { get; set; }

        public string? TenVitri { get; set; }

        public string? MoTaCv { get; set; }

        public double? MucLuongCoBan { get; set; }

        public DateTime? NgayDang { get; set; }

        public DateTime? HetHan { get; set; }

        public string? TrangThai { get; set; }

        public int? IdphongBan { get; set; }
    }
}
