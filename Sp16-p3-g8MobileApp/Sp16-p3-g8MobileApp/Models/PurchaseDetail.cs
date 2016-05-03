using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sp16p3g8MobileApp.Models
{
  public  class PurchaseDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string type { get; set; }

        public string time { get; set; }

        public int InventoryCount { get; set; }

        public string date { get; set; }

        public string ScreenNumber { get; set; }

        internal Task GetPurchaseAsync()
        {
            throw new NotImplementedException();
        }
    }
}
