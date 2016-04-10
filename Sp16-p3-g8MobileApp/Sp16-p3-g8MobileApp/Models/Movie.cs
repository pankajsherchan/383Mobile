using Newtonsoft.Json;
using Sp16p3g8MobileApp.Models;
using System;
using System.Collections.Generic;

namespace Sp16p3g8MobileApp
{
	public class Movie
	{
		public int ID{ get; set; }
		public string Name{ get; set; }
		public string ReleaseDate{ get; set; }
		public string Description { get; set; }
		public double Rating { get; set; }
        public string Cast { get; set; }
        [JsonIgnore]
        public virtual ICollection<Showtime> Showtime { get; set; } = new List<Showtime>();
       // public List<Showtime> Showtime { get; set; }
      //  public  List<Showtime> Showtime { get; set; }


	}
		
}



