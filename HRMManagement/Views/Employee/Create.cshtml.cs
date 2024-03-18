using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRMManagement.DI;
using HRMManagement.Models;

namespace HRMManagement.Views.Employee
{
    public class CreateModel : PageModel
    {
        private readonly HRMManagement.DI.HRMDBContext _context;

        public CreateModel(HRMManagement.DI.HRMDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdchucVu"] = new SelectList(_context.Chucvus, "Id", "Id");
        ViewData["IdphongBan"] = new SelectList(_context.Phongbans, "Id", "Id");
        ViewData["IdviTri"] = new SelectList(_context.Vitricvs, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Nhanvien Nhanvien { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Nhanviens == null || Nhanvien == null)
            {
                return Page();
            }

            _context.Nhanviens.Add(Nhanvien);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
