using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sp16_p3_g8_WebAPI.DTO_Service
{
    public class MovieDTO
    {
        public string title { get; set; }
        public string genre { get; set; }

        public string actors { get; set; }

        public double rating { get; set; }

        public string description { get; set; }

        public DateTime releaseDate { get; set; }
    }
}