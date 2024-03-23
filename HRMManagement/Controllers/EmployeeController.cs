using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMManagement.Models;
using HRMManagement.DI;

public class EmployeeController : Controller
{
    private readonly HRMDBContext _context;

    public EmployeeController(HRMDBContext context)
    {
        this._context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        //
        var employees = _context.Nhanviens.ToList();
        List<Nhanvien> employeeList = new List<Nhanvien>();

        //var employeesWithRelatedData = _context.NHANVIENs
        //    .Include(e => e.BANGCAPs)
        //    .Include(e => e.BAOHIEMs)
        //    .Include(e => e.CHAMCONGs)
        //    .Include(e => e.CHUCVU)
        //    .Include(e => e.DAOTAONHANVIENs)
        //    .Include(e => e.HOPDONGs)
        //    .Include(e => e.LUONGs)
        //    .Include(e => e.PHONGBAN)
        //    .Include(e => e.TAIKHOANs)
        //    .Include(e => e.TKNGANHANGs)
        //    .Include(e => e.YEUCAUNGHIPHEPs)
        //    .ToList();

        if (employees != null)
        { 
            foreach( var employee in employees) 
            { 
                var EmployeesViewModel = new Nhanvien() 
                {
                    Id = employee.Id,
                    HoDem = employee.HoDem,
                    Ten = employee.Ten,
                    NgaySinh = employee.NgaySinh,
                    GioiTinh = employee.GioiTinh,
                    Cccd = employee.Cccd,
                    DiaChi = employee.DiaChi,
                    Sdt = employee.Sdt,
                    Email = employee.Email,
                    QueQuan = employee.QueQuan,
                    NgayTuyenDung = employee.NgayTuyenDung,
                    AnhProfile = employee.AnhProfile,
                    IdviTri = employee.IdviTri,
                    IdchucVu = employee.IdchucVu,
                    IdphongBan = employee.IdphongBan,
                };
                employeeList.Add(EmployeesViewModel);
            }
            return View(employeeList);
        }

        return View(employeeList);
    }

    ////Display a single Emp
    //public IActionResult Display(String id)
    //{
    //    var Emp = _productRepository.GetById(id);
    //    if (Emp == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(Emp);
    //}
}
