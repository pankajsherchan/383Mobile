using FinalWebAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebAPI.APIHelper
{
    public class MovieAPI
    {
        
            public List<MovieName> GetMovie()
            {
          
            var client = new RestClient("http://api.themoviedb.org");
                var request = new RestRequest("/3/discover/movie?api_key=bd4ad9f94b172bb08b24a8c6dbf15766&primary_release_date.gte=2016-03-15&primary_release_date.lte=2016-04-22");
               var response = client.Execute<List<RootObject>>(request);

                var movieNameList = new List<MovieName>();

            Random rnd = new Random();
           

            foreach (var movie in response.Data[0].results)
                {
                movieNameList.Add(new MovieName()
                {
                    Name = movie.original_title,
                    

                    });
                }

                return movieNameList;
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

