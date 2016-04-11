using RestSharp;
using sp16_p3_g8WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sp16_p3_g8WebAPI.APIHelper
{
    public class MovieAPI
    {
       public List<Movie> GetMovie()
            {

                var client = new RestClient("http://api.themoviedb.org");
                var request = new RestRequest("/3/discover/movie?api_key=bd4ad9f94b172bb08b24a8c6dbf15766&primary_release_date.gte=2016-03-15&primary_release_date.lte=2016-04-22");
                var response = client.Execute<List<RootObject>>(request);

                var movieList = new List<Movie>();

                foreach (var movie in response.Data[0].results)
                {
                    movieList.Add(new Movie()
                    {
                        Name = movie.original_title,
                        Description = movie.overview,
                        Rating = movie.vote_count,
                        ReleaseDate = movie.release_date,
                        Cast = "fsjkl",
                        Duration = "55"
                    });
                }

                return movieList;
            }

        }


        public class Result
        {
            public string poster_path { get; set; }
            public bool adult { get; set; }
            public string overview { get; set; }
            public string release_date { get; set; }
            public List<int> genre_ids { get; set; }
            public int id { get; set; }
            public string original_title { get; set; }
            public string original_language { get; set; }
            public string title { get; set; }
            public string backdrop_path { get; set; }
            public double popularity { get; set; }
            public int vote_count { get; set; }
            public bool video { get; set; }
            public double vote_average { get; set; }
        }

        public class RootObject
        {
            public int page { get; set; }
            public List<Result> results { get; set; }
            public int total_results { get; set; }
            public int total_pages { get; set; }
        }

    }
 
    
