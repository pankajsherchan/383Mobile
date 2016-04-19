using FinalWebAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebAPI.APIHelper
{
    public class MovieAPI1
    {
        public List<Movie> Get()
        {
            var movieList = new List<Movie>();
            MovieAPI helper = new MovieAPI();
            List<MovieName> movieNameList = new List<MovieName>();
            movieNameList = helper.GetMovie();

            foreach (var movieName in movieNameList)
            {

                var client = new RestClient("http://omdbapi.com/");
                var request = new RestRequest("?t=" + movieName.Name);
                var response = client.Execute<List<RootObject1>>(request);

               

                Random rnd = new Random();


                foreach (var movie in response.Data)
                {
                    movieList.Add(new Movie()
                    {
                        Name = movie.Title,
                        ReleaseDate = movie.Year,
                        Duration = movie.Runtime,
                        imdbRating = movie.imdbRating,
                        Poster = movie.Poster,
                        Plot = movie.Plot,
                        Language = movie.Language,
                        Genre = movie.Genre,
                        Actors = movie.Actors,
                        Awards = movie.Awards,
                        Description = movie.Plot,
                        Director = movie.Director,
                        Year = movie.Year
                    });
                }
            }

                return movieList;


            }

        }
        public class RootObject1
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string Rated { get; set; }
            public string Released { get; set; }
            public string Runtime { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public string Writer { get; set; }
            public string Actors { get; set; }
            public string Plot { get; set; }
            public string Language { get; set; }
            public string Country { get; set; }
            public string Awards { get; set; }
            public string Poster { get; set; }
            public string Metascore { get; set; }
            public string imdbRating { get; set; }
            public string imdbVotes { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
            public string Response { get; set; }
        

    }
}