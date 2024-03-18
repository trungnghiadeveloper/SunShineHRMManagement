using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRMManagement.Data;
using HRMManagement.Models;

namespace HRMManagement.Views.Employee
{
    public class DeleteModel : PageModel
    {
        private readonly HRMManagement.Data.HRMManagementContext _context;

        public DeleteModel(HRMManagement.Data.HRMManagementContext context)
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

            var employeesviewmodel = await _context.EmployeesViewModel.FirstOrDefaultAsync(m => m.ID == id);

            if (employeesviewmodel == null)
            {
                return NotFound();
            }
            else 
            {
                EmployeesViewModel = employeesviewmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.EmployeesViewModel == null)
            {
                return NotFound();
            }
            var employeesviewmodel = await _context.EmployeesViewModel.FindAsync(id);

            if (employeesviewmodel != null)
            {
                EmployeesViewModel = employeesviewmodel;
                _context.EmployeesViewModel.Remove(EmployeesViewModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
