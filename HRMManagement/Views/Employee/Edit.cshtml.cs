using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMManagement.Data;
using HRMManagement.Models;

namespace HRMManagement.Views.Employee
{
    public class EditModel : PageModel
    {
        private readonly HRMManagement.Data.HRMManagementContext _context;

        public EditModel(HRMManagement.Data.HRMManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeesViewModel EmployeesViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.EmployeesViewModel == null)
            {
                return NotFound();
            }

            var employeesviewmodel =  await _context.EmployeesViewModel.FirstOrDefaultAsync(m => m.ID == id);
            if (employeesviewmodel == null)
            {
                return NotFound();
            }
            EmployeesViewModel = employeesviewmodel;
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

            _context.Attach(EmployeesViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesViewModelExists(EmployeesViewModel.ID))
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

        private bool EmployeesViewModelExists(string id)
        {
          return (_context.EmployeesViewModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
