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

namespace Sp16p3g8MobileApp
{
	public class MovieService : MovieServiceInterface
	{
		HttpClient client;
		public List<Movie> Items { get; private set; }

        ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
        public MovieService ()
		{
			client = new HttpClient ();
		}

        public async Task<List<Movie>> GetMovieAsync()
        {
            var client = new RestClient("http://192.168.1.40:30044/");
            var request = new RestRequest("api/movies", Method.GET);

            var response = await client.Execute<List<Movie>>(request);
            List<Movie> results = new List<Movie>();
            results = response.Data.OrderBy(m => m.Name).ToList();

            foreach (var movie in results)
            {
                movies.Add(new Movie()

                {
                    ID = movie.ID,
                    Name = movie.Name,
                    Rating = movie.Rating,
                    ReleaseDate = movie.ReleaseDate,
                    Description = movie.Description,
                    Cast=movie.Cast,
                    Showtime = movie.Showtime
                });


            }
            return movies.ToList();
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