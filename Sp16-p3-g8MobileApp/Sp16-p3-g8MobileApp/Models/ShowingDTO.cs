using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sp16p3g8MobileApp.Models
{
  public  class ShowingDTO
    {
            public int Id { get; set; }

            public string Name { get; set; }
            public string Poster { get; set; }

            public DateTime StartDate { get; set; }
            public string Genre { get; set; }
            public string Duration { get; set; }

            public string Description { get; set; }

            public string imdbRating { get; set; }
            public string Year { get; set; }


            public List<Showtime> showtimes { get; set; }

        }
}
