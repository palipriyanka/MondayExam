using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeMvc.Models.Views
{
    public class GoodsPurchaseViews
    {
        [Key]
        public int PurchaseId { get; set; }
        public string GoodsName { get; set; }
        public string PurchaseLoc { get; set; }
        public string PurchaseDelivery { get; set; }

    }
}
