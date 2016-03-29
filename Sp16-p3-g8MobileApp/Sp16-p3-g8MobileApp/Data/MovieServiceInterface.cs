using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sp16p3g8MobileApp
{
	public interface MovieServiceInterface
	{
		Task<List<Movie>> GetMovieAsync ();

		//Task SaveMovieAsync (Movie movie, bool IsNewMovie);

		//sTask DeleteMovieAsync (string id);
	}
}

