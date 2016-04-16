using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalWebAPI.Models
{
    public class Screen
    {
        /*
       Id yet again is the primary key
       ScreenNumber and Seatcount is for specific theatre
       */
        [Key]
        public int Id { get; set; }

        public string ScreenNumber { get; set; }

        public int SeatCount { get; set; }
    }
}