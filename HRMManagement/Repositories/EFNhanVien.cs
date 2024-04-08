using HRMManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HRMManagement.Repositories
{
    public class EFNhanVien : INhanVien
    {
        private readonly HrmContext _context;

        public EFNhanVien(HrmContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nhanvien>> GetAllAsync()
        {
            return await _context.Nhanviens.ToListAsync();
        }

        public async Task<Nhanvien> GetByIdAsync(string id)
        {
            return   await _context.Nhanviens.FindAsync(id);
            
        }

        public Task<Nhanvien> Update(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Updateimage(string id)
        {
            throw new NotImplementedException();
        }
    }
}
