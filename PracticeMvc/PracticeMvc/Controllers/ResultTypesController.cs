using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PracticeMvc.Data;

namespace PracticeMvc.Controllers
{
    public class ResultTypesController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ResultTypesController(ApplicationDbContext applicationDbContext,IWebHostEnvironment webHostEnvironment)
        {
            _applicationDbContext = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region NotFound

        public IActionResult NotFound(int? id)
        {
            if (id.HasValue)
            {
                return View();
            }
            else
            {
                return Redirect("https://www.Tollplus.com");
                return View();
            }
        }


        #endregion
    }
}
