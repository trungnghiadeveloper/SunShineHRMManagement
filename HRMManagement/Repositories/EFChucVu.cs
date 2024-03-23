using HRMManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMManagement.Repositories
{
    public class EFChucVu : IChucVu
    {
        private readonly HrmContext _context;

        public EFChucVu(HrmContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chucvu>> GetAllAsync()
        {
            return await _context.Chucvus.ToListAsync();
        }

        public async Task<Chucvu> GetByIdAsync(int id)
        {
            return await _context.Chucvus.FindAsync(id);
        }
    }
}
