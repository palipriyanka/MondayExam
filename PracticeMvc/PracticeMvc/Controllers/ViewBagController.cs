using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeMvc.Data;

namespace PracticeMvc.Controllers
{
    public class ViewBagController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ViewBagController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var employee1 = _applicationDbContext.Employee1.ToList();
            //ViewBag.name = "Priyanka";
            ViewBag.Employee1 = employee1;
            //ViewData["name"] = "Priyanka";
            return View(employee1);
        }
    }
}
