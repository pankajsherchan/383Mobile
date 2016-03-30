using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sp16_p3_g8_WebAPI.Models
{
    public class Movie
    {

        [Key]
        public int moviesId { get; set; }

        public string title { get; set; }

        public DateTime releaseDate { get; set; }

        public double rating { get; set; }

        public string description { get; set; }

        public string genre { get; set; }

        public string actors { get; set; }

    }
}