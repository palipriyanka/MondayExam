using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeMvc.Data;
using PracticeMvc.DependencyInjection;

namespace PracticeMvc.Controllers
{
    public class DIController1 : Controller
    {
        private readonly IAge _age;

        public DIController1(IAge age)
        {
            _age = age;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Index(IFormCollection form)
        {
            var dob = DateTime.Parse(form["YourAge"]);
            ViewBag.DOB = dob;
            ViewBag.YourAge = _age.GetMyAge(dob);
            return View();
        }

    }
}
