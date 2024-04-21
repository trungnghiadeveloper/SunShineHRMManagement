using HRMManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMManagement.Repositories
{
    public interface IUngVien
    {
        Task<IEnumerable<Ungvien>> GetAllAsync();
        Task<Ungvien> GetByIdAsync(string id);
    }
}
