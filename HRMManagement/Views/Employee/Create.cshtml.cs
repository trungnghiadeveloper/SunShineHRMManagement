using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRMManagement.Data;
using HRMManagement.Models;

namespace HRMManagement.Views.Employee
{
    public class CreateModel : PageModel
    {
        private readonly HRMManagement.Data.HRMManagementContext _context;

        public CreateModel(HRMManagement.Data.HRMManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmployeesViewModel EmployeesViewModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.EmployeesViewModel == null || EmployeesViewModel == null)
            {
                return Page();
            }

            _context.EmployeesViewModel.Add(EmployeesViewModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
