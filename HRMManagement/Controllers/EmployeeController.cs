using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMManagement.Models; 

public class EmployeeController : Controller
{
    private readonly EmpDBContext _context;

    public EmployeeController(EmpDBContext context)
    {
        this._context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        //
        var employees = _context.NHANVIENs.ToList();
        List<EmployeesViewModel> employeeList = new List<EmployeesViewModel>();

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
                var EmployeesViewModel = new EmployeesViewModel() 
                {
                    ID = employee.ID,
                    HoDem = employee.HoDem,
                    Ten = employee.Ten,
                    NgaySinh = employee.NgaySinh,
                    GioiTinh = employee.GioiTinh,
                    CCCD = employee.CCCD,
                    DiaChi = employee.DiaChi,
                    SDT = employee.SDT,
                    Email = employee.Email,
                    QueQuan = employee.QueQuan,
                    NgayTuyenDung = employee.NgayTuyenDung,
                    AnhProfile = employee.AnhProfile,
                    IDViTri = employee.IDViTri,
                    IDChucVu = employee.IDChucVu,
                    IDPhongBan = employee.IDPhongBan,
                };
                employeeList.Add(EmployeesViewModel);
            }
            return View(employeeList);
        }

        return View(employeeList);
    }

    // Display a single Emp
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
