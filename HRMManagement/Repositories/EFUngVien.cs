using HRMManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMManagement.Repositories
{
    public class EFUngVien : IUngVien
    {
        private readonly HrmContext _context;
        public EFUngVien(HrmContext context)
        {
            _context = context;
        }

        public async Task<Ungvien> GetByIdAsync(string id)
        {
            return await _context.Ungviens.FindAsync(id);
        }

        public async Task<IEnumerable<Ungvien>> GetAllAsync()
        {
            return await _context.Ungviens.ToListAsync();
        }
    }
}
