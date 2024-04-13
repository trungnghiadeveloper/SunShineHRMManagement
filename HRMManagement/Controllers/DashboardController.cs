using Microsoft.AspNetCore.Mvc;
using HRMManagement.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRMManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using System.Resources;
using System.Diagnostics;

namespace HRMManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly INhanVien _nhanvien;
        private readonly IChucVu _chucvu;
        private readonly HrmContext _context;

        public DashboardController(HrmContext context, INhanVien nhanvien)
        {
            _context = context;
            _nhanvien = nhanvien;
        }

        public IActionResult Index()
        {
            Dictionary<string, int> stats = getStats();

            ViewData["stats"] = stats;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public Dictionary<string, int> getStats()
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();

            int nhanvien = _context.Nhanviens.Count();

            stats.Add("nhanvien", nhanvien);

            return stats;
        }
    }
}
