using Newtonsoft.Json;
using Sp16p3g8MobileApp.Models;
using System;
using System.Collections.Generic;

namespace Sp16p3g8MobileApp
{
	public class Movie
	{
		public int Id{ get; set; }
		
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Poster { get; set; }
        public string ReleaseDate { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Awards { get; set; }
        public string imdbRating { get; set; }

        [JsonIgnore]
        public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();



    }

}



