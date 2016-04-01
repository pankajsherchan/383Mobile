using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sp16_p3_g8WebAPI.Models
{
    public class Showtime
    {
        /*
            showtime includes all the information
            Id -> primary id
            TheatreId -> foreign Key
            MovieId -> foreign Key
            StartDateTime -> starting date and time of a show
        */
        [Key]
        public int Id { get; set; }

        // get the screen information
        public int ScreenId { get; set; }

        public virtual Screen Screen { get; set; }

        // get the movie information
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public DateTime StartDateTime { get; set; }

    }
}