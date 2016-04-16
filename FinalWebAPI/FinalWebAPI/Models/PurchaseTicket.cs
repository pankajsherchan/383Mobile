using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalWebAPI.Models
{
    public class PurchaseTicket
    {
        /*
    Id->primarykey
    showtimeId -. foreign key 
    Showtime is related to movie and theater
    this way purchase ticket will have the info of movie,theater, showtime

    */
            [Key]
            public int Id { get; set; }

            public int ShowtimeId { get; set; }

            public virtual Showtime Showtime { get; set; }

            public int TicketCount { get; set; }


            public DateTime PurchaseDateTime { get; set; }

        }
    }