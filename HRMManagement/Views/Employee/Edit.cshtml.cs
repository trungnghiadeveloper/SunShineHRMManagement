using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMManagement.DI;
using HRMManagement.Models;

namespace HRMManagement.Views.Employee
{
    public class EditModel : PageModel
    {
        private readonly HRMManagement.DI.HRMDBContext _context;

        public EditModel(HRMManagement.DI.HRMDBContext context)
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

            var nhanvien =  await _context.Nhanviens.FirstOrDefaultAsync(m => m.Id == id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            Nhanvien = nhanvien;
           ViewData["IdchucVu"] = new SelectList(_context.Chucvus, "Id", "Id");
           ViewData["IdphongBan"] = new SelectList(_context.Phongbans, "Id", "Id");
           ViewData["IdviTri"] = new SelectList(_context.Vitricvs, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Nhanvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanvienExists(Nhanvien.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NhanvienExists(string id)
        {
          return (_context.Nhanviens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
