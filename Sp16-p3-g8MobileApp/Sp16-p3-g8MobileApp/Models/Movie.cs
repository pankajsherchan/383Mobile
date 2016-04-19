using Newtonsoft.Json;
using Sp16p3g8MobileApp.Models;
using System;
using System.Collections.Generic;

namespace Sp16p3g8MobileApp
{
	public class Movie
	{
		public int Id{ get; set; }
		public string Name{ get; set; }
		
		public string Description { get; set; }
		public int Rating { get; set; }

        public string Duration { get; set; }

        public string Poster { get; set; }
        public string ReleaseDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
     

	}
		
}



