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
				Title = "Movie1",
				ReleaseDate = "10/11/1995",
				Description= "fkajskfjskljdfjskld",
				Rating =6
			});

			MovieList.Add (new Movie {
				ID =2,
				Title = "Movie2",
				ReleaseDate = "10/11/1995",
				Description= "fkajskfjskljdfjskld",
				Rating =8
			});


			MovieList.Add (new Movie {
				ID =3,
				Title = "Movie3",
				ReleaseDate = "10/11/1995",
				Description= "fkajskfjskljdfjskld",
				Rating = 10
			});


			return MovieList;

		}
	}
		
}



