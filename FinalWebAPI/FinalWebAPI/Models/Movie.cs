using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalWebAPI.Models
{
    public class Movie
    {
        /*
      Id is the primary key for this model.
      Name, Description and .... are just samples movie info as per OMDB API
      */
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public string Duration { get; set; }


        //[DataType(DataType.Date)]
        //   [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string ReleaseDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Showtime> Showtimes { get; set; }

    }
}