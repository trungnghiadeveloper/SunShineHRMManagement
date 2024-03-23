
using HRMManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMManagement.Repositories

{
    public interface INhanVien
    {
        Task<IEnumerable<Nhanvien>> GetAllAsync();
        Task<Nhanvien> GetByIdAsync(string id);
        Task<IActionResult> Updateimage(string id);
    }
}
