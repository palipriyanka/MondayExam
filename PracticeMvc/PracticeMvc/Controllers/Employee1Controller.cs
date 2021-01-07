using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PracticeMvc.Data;
using PracticeMvc.DependencyInjection;
using PracticeMvc.Models;

using X.PagedList;

namespace PracticeMvc.Controllers
{
    public class Employee1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;
        //private readonly ILogger _logger;

        public Employee1Controller(ApplicationDbContext context,IMemoryCache memoryCache,IDistributedCache distributedCache)
        {
            _context = context;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
           // _logger = logger;
        }

        // GET: Employee1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee1.ToListAsync());
        }

       


        #region  Raw Query

        public IActionResult RawQuery()
        {
            var sql = "Select * from Employee1";
            var data = _context.Employee1.FromSqlRaw(sql).ToList();
            return View(data);
        }
        #endregion

        #region raw query pasing id
        public IActionResult RawQueryId(int id)
        {
            var sql = "Select * from Employee1 where id=1";
            var data = _context.Employee1.FromSqlRaw(sql,id).FirstOrDefault();
            return View(data);
        }
        #endregion

        #region  Paging

        //public async Task<IActionResult> Paging(int? page,int? pagesize)
        //{
        //    if (!page.HasValue)
        //    {
        //        page = 1;
        //    }
        //    if(!pagesize.HasValue)
        //    {
        //        pagesize = 5;
        //    }
        //    var data = await _context.Employee1.ToPagedListAsync(page.Value, pagesize.Value);
        //    return View(data);
        //}
        public async Task<IActionResult> Paging(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 4;
            var uni = _context.Employee1.OrderBy(u => u.id).ToPagedList(pageNumber, pageSize);
            return View(uni);
        }


        #endregion

        #region Search 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(IFormCollection form)
        {
            var feildname = form["Feildname"].ToString();
            var keyword = form["keyWord"].ToString();
            IList<Employee1> employee1 = new List<Employee1>();
            switch (feildname)
            {
                case "id":
                    var id = int.Parse(keyword);
                    employee1 = _context.Employee1.Where(d => d.id.Equals(id)).ToList();
                    break;
                case "name":
                    employee1 = _context.Employee1.Where(d => d.name.StartsWith(keyword)).ToList();
                    break;
                case "salary":
                    var salary = decimal.Parse(keyword);
                    employee1 = _context.Employee1.Where(d => d.salary.Equals(salary)).ToList();
                    break;
                default:
                    break;
            }
            return View(employee1);
        }

        public IActionResult Search()
        {
            return View(new List<Employee1>());
        }


        #endregion

        #region inmemory cache

        public async Task<IActionResult> CacheIndex()
        {
            var CacheData = _memoryCache.Get("EmployeeData");
            IList<Employee1> data = new List<Employee1>();
            if (CacheData == null)
            {
                data = await _context.Employee1.ToListAsync();
                var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _memoryCache.Set("EmployeeData", data, cacheOptions);
            }
            else
            {
                data = (IList<Employee1>)CacheData;
            }
            return View(data);
        }
        public IActionResult RemoveCache()
        {
            _memoryCache.Remove("EmployeeData");
            return RedirectToAction("CacheIndex");
        }

        #endregion

        #region Distributed Cache

        public async Task<IActionResult> RadisCache()
        {
            IList<Employee1> data = new List<Employee1>();
            var isCacheString = _distributedCache.GetString("RadisData");
            if (string.IsNullOrEmpty(isCacheString))
            {
                data = await _context.Employee1.ToListAsync();
                var dataString = JsonConvert.SerializeObject(data);
                var distributedCacheOptions = new DistributedCacheEntryOptions();
                distributedCacheOptions.SetSlidingExpiration(TimeSpan.FromSeconds(10));
                await _distributedCache.SetStringAsync("RadisData", dataString, distributedCacheOptions);
            }
            else
            {
                data = JsonConvert.DeserializeObject<IList<Employee1>>(isCacheString);
            }
            return View(data);
        }
        public IActionResult RemoveRaadisCache()
        {
            _distributedCache.Remove("RadisData");
            return RedirectToAction("RadisCache");
        }

        #endregion




        // GET: Employee1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee1 = await _context.Employee1
                .FirstOrDefaultAsync(m => m.id == id);
            if (employee1 == null)
            {
                return NotFound();
            }

            return View(employee1);
        }

        // GET: Employee1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,salary")] Employee1 employee1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee1);
        }

        // GET: Employee1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee1 = await _context.Employee1.FindAsync(id);
            if (employee1 == null)
            {
                return NotFound();
            }
            return View(employee1);
        }

        // POST: Employee1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,salary")] Employee1 employee1)
        {
            if (id != employee1.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee1Exists(employee1.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee1);
        }

        // GET: Employee1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee1 = await _context.Employee1
                .FirstOrDefaultAsync(m => m.id == id);
            if (employee1 == null)
            {
                return NotFound();
            }

            return View(employee1);
        }

        // POST: Employee1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee1 = await _context.Employee1.FindAsync(id);
            _context.Employee1.Remove(employee1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee1Exists(int id)
        {
            return _context.Employee1.Any(e => e.id == id);
        }
    }
}
