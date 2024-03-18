using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRMManagement.DI;
using HRMManagement.Models;

namespace HRMManagement.Views.Employee
{
    public class IndexModel : PageModel
    {
        private readonly HRMManagement.DI.HRMDBContext _context;

        public IndexModel(HRMManagement.DI.HRMDBContext context)
        {
            _context = context;
        }

        public IList<Nhanvien> Nhanvien { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Nhanviens != null)
            {
                Nhanvien = await _context.Nhanviens
                .Include(n => n.IdchucVuNavigation)
                .Include(n => n.IdphongBanNavigation)
                .Include(n => n.IdviTriNavigation).ToListAsync();
            }
        }
    }
}
