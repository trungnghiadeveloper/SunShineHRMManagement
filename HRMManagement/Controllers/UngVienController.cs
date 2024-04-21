using Microsoft.AspNetCore.Mvc;
using HRMManagement.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRMManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using System.Resources;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HRMManagement.Controllers
{
    public class UngVienController : Controller
    {
        private readonly IUngVien? _ungvien;
        private readonly IViTricv? _vitricv;

        private readonly HrmContext? _context;

        // GET: UngVienController
        public ActionResult Index(string searchString)
        {
            var _Ungvien = (from uv in _context.Ungviens
                            join pv in _context.Phongvans on uv.Id equals pv.IdungVien
                            join nv in _context.Nhanviens on pv.NguoiPhongVan equals nv.Id
                            select new UngVienViewModel
                            {
                                //UngVien
                                Id = uv.Id,
                                HoDem = uv.HoDem,
                                Ten = uv.Ten,
                                NgaySinh = uv.NgaySinh,
                                GioiTinh = uv.GioiTinh,
                                Cccd = uv.Cccd,
                                DiaChi = uv.DiaChi,
                                Sdt = uv.Sdt,
                                Email = uv.Email,
                                QueQuan = uv.QueQuan,
                                NgayUngTuyen = uv.NgayUngTuyen,
                                LinkHoSo = uv.LinkHoSo,
                                //PhongVan
                                IdPhongVan = pv.Id,
                                NgayPhongVan = pv.NgayPhongVan,
                                NguoiPhongVan = pv.NguoiPhongVan,
                                GhiChu = pv.GhiChu,
                                KetQua = pv.KetQua,
                                //// Lấy thông tin từ ICollection Tuyendungs của Ungvien
                                //IdTuyenDung = (int)(uv.Tuyendungs.FirstOrDefault()?.Id),
                                //NgayDeNghi = uv.Tuyendungs.FirstOrDefault()?.NgayDeNghi,
                                //ThongTinChiTiet = uv.Tuyendungs.FirstOrDefault()?.ThongTinChiTiet,
                                //IdviTri = uv.Tuyendungs.FirstOrDefault()?.IdviTri,

                                //// Lấy thông tin từ danh sách _thongTinPV
                                //TenVitri = _thongTinPV.FirstOrDefault(t => t.IdviTri == uv.Tuyendungs.FirstOrDefault()?.IdviTri)?.TenVitri,
                                //MoTaCv = _thongTinPV.FirstOrDefault(t => t.IdviTri == uv.Tuyendungs.FirstOrDefault()?.IdviTri)?.MoTaCv,
                                //MucLuongCoBan = _thongTinPV.FirstOrDefault(t => t.IdviTri == uv.Tuyendungs.FirstOrDefault()?.IdviTri)?.MucLuongCoBan,
                                //NgayDang = _thongTinPV.FirstOrDefault(t => t.IdviTri == uv.Tuyendungs.FirstOrDefault()?.IdviTri)?.NgayDang,
                                //HetHan = _thongTinPV.FirstOrDefault(t => t.IdviTri == uv.Tuyendungs.FirstOrDefault()?.IdviTri)?.HetHan,
                                //TrangThai = _thongTinPV.FirstOrDefault(t => t.IdviTri == uv.Tuyendungs.FirstOrDefault()?.IdviTri)?.TrangThai,
                                //IdphongBan = _thongTinPV.FirstOrDefault(t => t.IdviTri == uv.Tuyendungs.FirstOrDefault()?.IdviTri)?.IdphongBan,
                            }).ToList();



            // Search
            if (!string.IsNullOrEmpty(searchString) && _Ungvien != null)
            {
                if (searchString == "all" || searchString == "All")
                {
                    return View(_Ungvien);
                }
                _Ungvien = _Ungvien.Where(n => (n.TenVitri != null && n.TenVitri.Contains(searchString)
                      || (n.Email != null && n.Email.Contains(searchString))
                      || (n.GhiChu != null && n.GhiChu.Contains(searchString))
                      || n.Ten != null && n.Ten.Contains(searchString))
                      || (n.HoDem != null && n.HoDem.Contains(searchString))
                      || (n.Ten != null && n.HoDem != null && (n.HoDem + " " + n.Ten).Contains(searchString))
                      || (n.Id != null && n.Id.Contains(searchString))
                      || (n.Sdt != null && n.Sdt.Contains(searchString))
                      || (n.Cccd != null && n.Cccd.Contains(searchString))
                      // More ...
                      ).OrderBy(n => n.Ten).ToList();
            }

            return View(_Ungvien);
        }

        // GET: UngVienController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UngVienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UngVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UngVienController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UngVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UngVienController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UngVienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
