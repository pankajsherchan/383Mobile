using System;
using System.Collections.Generic;

namespace Sp16p3g8MobileApp
{
	public class Movie
	{
		public int ID{ get; set; }
		public string Title{ get; set; }
		public string ReleaseDate{ get; set; }
		public string Description { get; set; }
		public double Rating { get; set; }


		public static List<Movie> GetMovieList()
		{
			var MovieList = new List<Movie> ();

			MovieList.Add (new Movie {
				ID =1,
				Title = "Task1",
				ReleaseDate = "Location1",
				Description= "fkajskfjskljdfjskld",
				Rating =6
			});

			MovieList.Add (new Movie {
				ID =2,
				Title = "Task2",
				ReleaseDate = "Location2",
				Description= "fkajskfjskljdfjskld",
				Rating =8
			});


			MovieList.Add (new Movie {
				ID =3,
				Title = "Task3",
				ReleaseDate = "Location3",
				Description= "fkajskfjskljdfjskld",
				Rating = 10
			});


			return MovieList;

		}
	}
		
}



