using Microsoft.AspNetCore.Mvc;
using HRMManagement.Models;
using System.Diagnostics;

namespace HRMManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HrmContext _context;

        public DashboardController(HrmContext context)
        {
            _context = context;
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

            DateTime today = DateTime.Today;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            const string ActiveContractStatus = "Đang hoạt động";
            const string InActiveContractStatus = "Không hoạt động";
            const string AcceptedInterviewStatus = "Chấp nhận";
            const string ApprovedLeaveStatus = "Chấp thuận";
            const string MasterDegree = "Bằng Thạc sĩ";
            const string BachelorDegree = "Bằng Cử nhân";
            const string EngineerDegree = "Bằng Kỹ sư";
            const int TotalWorkingDays = 22;

            stats.Add("khoa_dt", _context.Khoadaotaos.Count());
            stats.Add("daotao", _context.Daotaonhanviens.Count(daotao => daotao.NgayHoanThanh >= startOfMonth && daotao.NgayHoanThanh <= endOfMonth));
            stats.Add("hopdong", CountBangCaps(startOfMonth, endOfMonth, ActiveContractStatus));
            stats.Add("hopdong_hethan", CountHopDongs(startOfMonth, endOfMonth, InActiveContractStatus));
            stats.Add("nhanvien_nhanbang_thacsi", CountBangCaps(startOfMonth, endOfMonth, MasterDegree));
            stats.Add("nhanvien_nhanbang_kysu", CountBangCaps(startOfMonth, endOfMonth, EngineerDegree));
            stats.Add("nhanvien_nhanbang_cunhan", CountBangCaps(startOfMonth, endOfMonth, BachelorDegree));
            stats.Add("ungvienmoi", _context.Nhanviens.Count());
            stats.Add("nhanvien", _context.Nhanviens.Count());
            stats.Add("nhanvienmoi", _context.Phongvans.Count(phongvan => phongvan.KetQua == AcceptedInterviewStatus));
            stats.Add("nhanvien_thieugiolam", _context.Chamcongs.Count(chamcong => chamcong.SoNgayLam < TotalWorkingDays));
            stats.Add("nhanvien_nghiphep", _context.Yeucaunghipheps.Count(nghiphep => nghiphep.NgayBatDau >= startOfMonth && nghiphep.NgayKetThuc <= endOfMonth && nghiphep.TrangThai.Contains(ApprovedLeaveStatus)));
            stats.Add("vitri_tuyen_dung", _context.Tuyendungs.Count(tuyendung => tuyendung.NgayDeNghi >= startOfMonth && tuyendung.NgayDeNghi <= endOfMonth));

            return stats;
        }

        private int CountBangCaps(DateTime startOfMonth, DateTime endOfMonth, string degree)
        {
            return _context.Bangcaps.Count(bangcap => bangcap.Ngay >= startOfMonth && bangcap.Ngay <= endOfMonth && bangcap.TenBang.Contains(degree));
        }
        private int CountHopDongs(DateTime startOfMonth, DateTime endOfMonth, string degree)
        {
            return _context.Hopdongs.Count(hopdong => hopdong.NgayBatDau >= startOfMonth && hopdong.NgayBatDau <= endOfMonth && hopdong.TrangThai.Contains(degree));
        }
    }
}
