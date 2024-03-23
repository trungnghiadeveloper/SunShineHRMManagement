using HRMManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMManagement.Repositories
{
    public class EFViTricv : IViTricv
    {
        private readonly HrmContext _context;

        public EFViTricv(HrmContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vitricv>> GetAllAsync()
        {
            return await _context.Vitricvs.ToListAsync();
        }

        public async Task<Vitricv> GetByIdAsync(int id)
        {
            return await _context.Vitricvs.FindAsync(id);
        }
    }
}
