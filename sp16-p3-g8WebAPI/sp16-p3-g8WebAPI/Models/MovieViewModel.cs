using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sp16_p3_g8WebAPI.Models
{
    public class MovieViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public string Duration { get; set; }

        public string Cast { get; set; }

        public string ReleaseDate { get; set; }

    }
}