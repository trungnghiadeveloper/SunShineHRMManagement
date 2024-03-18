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
    public class DeleteModel : PageModel
    {
        private readonly HRMManagement.DI.HRMDBContext _context;

        public DeleteModel(HRMManagement.DI.HRMDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Nhanvien Nhanvien { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FirstOrDefaultAsync(m => m.Id == id);

            if (nhanvien == null)
            {
                return NotFound();
            }
            else 
            {
                Nhanvien = nhanvien;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }
            var nhanvien = await _context.Nhanviens.FindAsync(id);

            if (nhanvien != null)
            {
                Nhanvien = nhanvien;
                _context.Nhanviens.Remove(Nhanvien);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
