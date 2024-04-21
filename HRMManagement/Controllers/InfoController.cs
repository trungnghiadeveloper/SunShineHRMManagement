using Microsoft.AspNetCore.Mvc;
using HRMManagement.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRMManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using System.Resources;

namespace HRMManagement.Controllers
{
    public class InfoController : Controller
    {
        private readonly INhanVien _nhanvien;
        private readonly IChucVu _chucvu;
        private readonly HrmContext _context;

        public InfoController(HrmContext context, INhanVien nhanvien)
        {
            _context = context;
            _nhanvien = nhanvien;
        }


        public async Task<IActionResult> Index(string searchString, string positionFilter, string titleFilter, string departmentFilter, int? pageNumber)
        {
            List<Display> query = (from nv in _context.Nhanviens
                                   join cv in _context.Chucvus
                                   on nv.IdchucVu equals cv.Id
                                   join pb in _context.Phongbans
                                   on nv.IdphongBan equals pb.Id
                                   join vt in _context.Vitricvs
                                   on nv.IdviTri equals vt.Id
                                   select new Display
                                   {
                                       Id = nv.Id,
                                       HoDem = nv.HoDem,
                                       Ten = nv.Ten,
                                       TenChucVu = cv.TenChucVu,
                                       TenPhongBan = pb.TenPhongBan,
                                       TenVitri = vt.TenVitri
                                   }).ToList();

            // Search
            if (!string.IsNullOrEmpty(searchString) && query != null)
            {
                if (searchString == "all")
                {
                    return View(query);
                }

                searchString = searchString.ToLowerInvariant();

                query = query.Where(n =>
                    (n.TenPhongBan != null && n.TenPhongBan.ToLowerInvariant().Contains(searchString))
                    || (n.TenVitri != null && n.TenVitri.ToLowerInvariant().Contains(searchString))
                    || (n.TenChucVu != null && n.TenChucVu.ToLowerInvariant().Contains(searchString))
                    || (n.Ten != null && n.Ten.ToLowerInvariant().Contains(searchString))
                    || (n.HoDem != null && n.HoDem.ToLowerInvariant().Contains(searchString))
                    || (n.Ten != null && n.HoDem != null && (n.HoDem + " " + n.Ten).ToLowerInvariant().Contains(searchString))
                    || (n.Id != null && n.Id.ToString().ToLowerInvariant().Contains(searchString)) 
                    || (n.Sdt != null && n.Sdt.ToLowerInvariant().Contains(searchString))
                    || (n.Cccd != null && n.Cccd.ToLowerInvariant().Contains(searchString))
                // More ...
                ).OrderBy(n => n.Ten).ToList();
            }

            // Filter

            if (!string.IsNullOrEmpty(departmentFilter) && query != null)
            {
                query = query.Where(n => n.TenPhongBan != null && n.TenPhongBan != null && n.TenPhongBan.Contains(departmentFilter)).ToList();
            }
            if (!string.IsNullOrEmpty(titleFilter) && query != null)
            {
                query = query.Where(n => n.TenChucVu != null && n.TenChucVu != null && n.TenChucVu.Contains(titleFilter)).ToList();
            }
            if (!string.IsNullOrEmpty(positionFilter) && query != null)
            {
                query = query.Where(n => n.TenVitri != null && n.TenVitri != null && n.TenVitri.Contains(positionFilter)).ToList();
            }


            // Filters take advantage of the search feature
            // Get the unique presence of columns  
            var uniquePhongBan = query.Select(n => n.TenPhongBan).Distinct().OrderBy(x => x).ToList();
            var uniqueChucVu = query.Select(n => n.TenChucVu).Distinct().OrderBy(x => x).ToList();
            var uniqueViTri = query.Select(n => n.TenVitri).Distinct().OrderBy(x => x).ToList();
            

            ViewBag.uniquePhongBan = uniquePhongBan;
            ViewBag.uniqueChucVu = uniqueChucVu;
            ViewBag.uniqueViTri = uniqueViTri;

            ////

            if (pageNumber == null || pageNumber < 1)
            {
                pageNumber = 1;
            }

            int pageSize = 5;

            return View(PaginatedList<Display>.Create(query, pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Display(string id)
        {
            var query = (from nv in _context.Nhanviens
                         join cv in _context.Chucvus
                         on nv.IdchucVu equals cv.Id
                         join pb in _context.Phongbans
                         on nv.IdphongBan equals pb.Id
                         join vt in _context.Vitricvs
                         on nv.IdviTri equals vt.Id
                         select new Display
                         {
                             Id = nv.Id,
                             HoDem = nv.HoDem,
                             Ten = nv.Ten,
                             NgaySinh = nv.NgaySinh,
                             GioiTinh = nv.GioiTinh,
                             Cccd = nv.Cccd,
                             DiaChi = nv.DiaChi,
                             Sdt = nv.Sdt,
                             Email = nv.Email,
                             TenChucVu = cv.TenChucVu,
                             TenPhongBan = pb.TenPhongBan,
                             TenVitri = vt.TenVitri
                         }).ToList();
            var ma = query.FirstOrDefault(p => p.Id == id);

            return View(ma);
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName);

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName;
        }
       

        public async Task<IActionResult> Updateimage(string id)
        {
            var nv= await _nhanvien.GetByIdAsync(id);
            if (nv == null)
            {
                return NotFound();
            }
            return View(nv);
        }

        [HttpPost]
        public async Task<IActionResult> Updateimage(string id, Nhanvien product, IFormFile imageUrl)
        {
            ModelState.Remove("ImageUrl"); // Loại bỏ xác thực ModelState cho

            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingProduct = await _nhanvien.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync
                                                                        // Giữ nguyên thông tin hình ảnh nếu không có hình mới được

                if (imageUrl == null)
                {
                    product.AnhProfile = existingProduct.AnhProfile;
                }
                else
                {
                    string myString = imageUrl.ToString();
                   
                    // Lưu hình ảnh mới
                 //   product.AnhProfile = await SaveImage(imageUrl);
                }

                existingProduct.AnhProfile= product.AnhProfile;

                await _nhanvien.Updateimage(existingProduct.ToString());
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}