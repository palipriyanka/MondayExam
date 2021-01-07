using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticeMvc.Models;
using PracticeMvc.Data;
using X.PagedList;
using Microsoft.EntityFrameworkCore;

namespace PracticeMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger ,ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            string key = "MyCookie";
            string value = "Welcome";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddSeconds(40);
            Response.Cookies.Append(key, value, cookieOptions);
            return View("Index");
        }

        #region TagHelper

        public IActionResult TagHelper()
        {
            return View();
        }

        #endregion

        #region raw Query

        public IActionResult RawQuery()
        {
            var sql = "Select * from Employee1";
            var sql1 = "Select * from Department";
            var data = context.Employee1.FromSqlRaw(sql,sql1).ToList();
            return View(data);
        }

        #endregion

        public IActionResult Read()
        {
            string key = "MyCookie";
            var cookieValue = Request.Cookies[key];
            return View("Index");
        }

        public IActionResult Remove()
        {
            string key = "MyCookie";
            string value = " ";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddSeconds(40);
            Response.Cookies.Append(key, value, cookieOptions);
            return View("Index");
        }
        public async Task<IActionResult> Paging(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 2;
            var uni = context.Employee1.OrderBy(u => u.id).ToPagedList(pageNumber, pageSize);
            return View(uni);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
