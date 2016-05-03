using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Sp16p3g8MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sp16p3g8MobileApp.Data
{
    public class PurchaseHistory
    {

        HttpClient client;
        List<PurchaseDetail> results = new List<PurchaseDetail>();

        ObservableCollection<PurchaseDetail> purchaseHistory = new ObservableCollection<PurchaseDetail>();
        public PurchaseHistory()
        {
            client = new HttpClient();
        }
        
        public async Task<List<PurchaseDetail>> GetPurchaseAsync()
        {

            // var client = new RestClient("http://192.168.1.40:51269/");
            //  var client = new RestClient("http://192.168.1.17:51269/");
            var client = new RestClient("http://147.174.187.34:51269/");
            var request = new RestRequest("api/PurchaseDetails", Method.GET);

            var response = await client.Execute<List<PurchaseDetail>>(request);

            results = response.Data.OrderBy(m => m.Id).ToList();

            foreach (var item in results)
            {
                purchaseHistory.Add(new PurchaseDetail()
                {
                    Id = item.Id,
                    Name =item.Name,
                    Price =item.Price,
                    ScreenNumber =item.ScreenNumber,
                    InventoryCount = item.InventoryCount,
                    time =item.time,
                    type =item.type,
                    date = item.date
                    
                });


            }
            return purchaseHistory.ToList();
        }
    }
  
}
