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
    public class IndexModel : PageModel
    {
        private readonly HRMManagement.Data.HRMManagementContext _context;

        public IndexModel(HRMManagement.Data.HRMManagementContext context)
        {
            _context = context;
        }

        public IList<EmployeesViewModel> EmployeesViewModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EmployeesViewModel != null)
            {
                EmployeesViewModel = await _context.EmployeesViewModel.ToListAsync();
            }
        }
    }
}
