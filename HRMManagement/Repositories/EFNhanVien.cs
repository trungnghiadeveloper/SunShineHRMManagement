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
        public async Task UpdateAsync(Nhanvien nv)
        {
            _context.Nhanviens.Update(nv);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(Nhanvien nv)
        {
            _context.Nhanviens.Add(nv);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var nv = await _context.Nhanviens.FindAsync(id);
            _context.Nhanviens.Remove(nv);
            await _context.SaveChangesAsync();
        }


        public Task<IActionResult> UploadImage(string id)
        {
            throw new NotImplementedException();
        }
    }
}
