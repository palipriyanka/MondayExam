using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeMvc.ViewComponents
{
    public class EmployeeViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public EmployeeViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _context.Employee1.ToListAsync();
            return View(data);
        }
    }
}
