using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;


namespace Sp16p3g8MobileApp
{
	public class MovieService : MovieServiceInterface
	{
		HttpClient client;
		public List<Movie> Items { get; private set; }

		public MovieService ()
		{
			client = new HttpClient ();

		
		}

		public async Task<List<Movie>> GetMovieAsync ()
		{

            HttpClient client = new HttpClient();
            Items = new List<Movie> ();

			var uri = new Uri (string.Format (Constant.RestUrl, string.Empty));


			try {
					var response = await client.GetAsync (uri);
						if (response.IsSuccessStatusCode) {
							var content = await response.Content.ReadAsStringAsync ();
							Items = JsonConvert.DeserializeObject <List<Movie>> (content);
						}
					} catch (Exception ex) {
						Debug.WriteLine (@"ERROR {0}", ex.Message);
					}

					return Items;
				}

	}
}