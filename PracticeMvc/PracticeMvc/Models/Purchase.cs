using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeMvc.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string PurchaseLoc { get; set; }
        public string PurchaseDelivery { get; set; }
    }
}
