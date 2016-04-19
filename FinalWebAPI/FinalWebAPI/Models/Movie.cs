using FinalWebAPI.Validation;
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
        [CheckIfExistsMovie]
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
        public virtual ICollection<Showtime> Showtimes { get; set; }

    }
}