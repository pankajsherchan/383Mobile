using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalWebAPI.Models
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

       public int ScreenId { get; set; }
        public virtual Screen Screen { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
       
        public DateTime StartDateTime { get; set; }

    }
}