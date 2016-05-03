using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using System.Linq;
using Sp16p3g8MobileApp.Models;

namespace Sp16p3g8MobileApp
{
    public class MovieService : MovieServiceInterface
    {
        HttpClient client;
        public List<Showtime> Items { get; private set; }
        List<Showtime> results = new List<Showtime>();
        List<PurchaseDetail> results1 = new List<PurchaseDetail>();
        ObservableCollection<PurchaseDetail> purchaseHistory = new ObservableCollection<PurchaseDetail>();
        ObservableCollection<Showtime> showtimes = new ObservableCollection<Showtime>();
        public MovieService()
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

            results1 = response.Data.OrderBy(m => m.Id).ToList();

            foreach (var item in results1)
            {
                purchaseHistory.Add(new PurchaseDetail()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    ScreenNumber = item.ScreenNumber,
                    InventoryCount = item.InventoryCount,
                    time = item.time,
                    type = item.type,
                    date = item.date

                });


            }
            return purchaseHistory.ToList();
        }

        public async Task<List<Showtime>> GetMovieAsync()
        {
            // var client = new RestClient("http://192.168.1.40:51269/");
            //  var client = new RestClient("http://192.168.1.17:51269/");
            var client = new RestClient("http://147.174.187.34:51269/");
            var request = new RestRequest("api/showtimes", Method.GET);
            var request1 = new RestRequest("api/movies", Method.GET);

            var response = await client.Execute<List<Showtime>>(request);
            var response1 = await client.Execute<List<ShowingDTO>>(request1);

            results = response.Data.OrderBy(m => m.Id).ToList();

            foreach (var showtime in results)
            {
                if (check(showtime))
                {
                    showtimes.Add(new Showtime()

                    {
                        Id = showtime.Id,
                        MovieId = showtime.MovieId,
                        Movie = showtime.Movie,
                        ScreenId = showtime.ScreenId,
                        StartDate = showtime.StartDate,
                        StartTime = showtime.StartTime,

                        Screen = showtime.Screen
                    });
                }

            }
            return showtimes.ToList();
        }

        public Boolean check(Showtime showtime)
         {
            foreach (var show in showtimes)
            {
                if (show.MovieId == showtime.MovieId)
                {
                    return false;
                }
            }
            return true;

    }
}
}

        //public async Task<List<Movie>> GetMovieAsync ()
        //{

        //	Items = new List<Movie> ();

        //	var uri = new Uri (string.Format (Constant.RestUrl, string.Empty));

        //	try {
        //			var response = await client.GetAsync (uri);
        //				if (response.IsSuccessStatusCode) {
        //					var content = await response.Content.ReadAsStringAsync ();
        //			//var rootObject = new RestSharp.Deserializers.JsonDeserializer().Deserialize<List<Game>>(response);
        //					Items = JsonConvert.DeserializeObject <List<Movie>> (content);
        //				}
        //			} catch (Exception ex) {
        //				Debug.WriteLine (@"ERROR {0}", ex.Message);
        //			}

        //			return Items;
        //		}

    
