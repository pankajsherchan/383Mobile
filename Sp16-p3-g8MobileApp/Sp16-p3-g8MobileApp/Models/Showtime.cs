using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sp16p3g8MobileApp.Models
{
   public class Showtime
    {
        public int Id { get; set; }

        // get the screen information
        public int ScreenId { get; set; }

        public Screen Screen { get; set; }

        // get the movie information
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public DateTime StartDateTime { get; set; }
    }
}
