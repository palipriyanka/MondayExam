using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeMvc.Data;
using PracticeMvc.Models.Views;

namespace PracticeMvc.Controllers
{
    public class GoodsPurchaseController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GoodsPurchaseController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RawQueryComplex(int id)
        {
            IList<GoodsPurchaseViews> list = new List<GoodsPurchaseViews>();
            using (var conn=_applicationDbContext.Database.GetDbConnection())
            {
                conn.Open();
                using(var command = conn.CreateCommand())
                {
                    var sql = "Select g.PurchaseId,g.GoodsName,p.PurchaseLoc,p.PurchaseDelivery from Goods g, Purchase p Where g.PurchaseId=p.PurchaseId";
                    command.CommandText = sql;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var record = new GoodsPurchaseViews()
                                {
                                    PurchaseId = reader.GetInt32(0),
                                    GoodsName = reader.GetString(1),
                                    PurchaseLoc = reader.GetString(2),
                                    PurchaseDelivery = reader.GetString(3)
                                };
                                list.Add(record);
                            }
                        }
                    }
                }
                conn.Close();
            }
            return View(list);
        }
    }
}
