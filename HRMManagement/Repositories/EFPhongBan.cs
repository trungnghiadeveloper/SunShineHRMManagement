using HRMManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMManagement.Repositories
{
    public class EFPhongBan : IPhongBan
    {
        private readonly HrmContext _context;

        public EFPhongBan(HrmContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Phongban>> GetAllAsync()
        {
            return await _context.Phongbans.ToListAsync();
        }

        public async Task<Phongban> GetByIdAsync(int id)
        {
            return await _context.Phongbans.FindAsync(id);
        }
    }
}
