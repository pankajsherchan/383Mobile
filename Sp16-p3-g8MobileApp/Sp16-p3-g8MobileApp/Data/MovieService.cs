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

        ObservableCollection<Showtime> showtimes = new ObservableCollection<Showtime>();
        public MovieService ()
		{
			client = new HttpClient ();
		}

        public async Task<List<Showtime>> GetMovieAsync()
        {
           // var client = new RestClient("http://192.168.1.40:51269/");
          //  var client = new RestClient("http://192.168.1.17:51269/");
            var client = new RestClient("http://147.174.168.44:51269/");
            var request = new RestRequest("api/showtimes", Method.GET);

            var response = await client.Execute<List<Showtime>>(request);
            List<Showtime> results = new List<Showtime>();
            results = response.Data.OrderBy(m => m.Id).ToList();

            foreach (var showtime in results)
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
            return showtimes.ToList();
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

    }
}