using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sp16_p3_g8WebAPI.Models
{
    public class sp16_p3_g8WebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public sp16_p3_g8WebAPIContext() : base("name=sp16_p3_g8WebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<sp16_p3_g8WebAPI.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<sp16_p3_g8WebAPI.Models.Screen> Screens { get; set; }

        public System.Data.Entity.DbSet<sp16_p3_g8WebAPI.Models.Showtime> Showtimes { get; set; }

        public System.Data.Entity.DbSet<sp16_p3_g8WebAPI.Models.PurchaseTicket> PurchaseTickets { get; set; }

        public System.Data.Entity.DbSet<sp16_p3_g8WebAPI.Models.PurchaseTicketLineItem> PurchaseTicketLineItems { get; set; }

        public System.Data.Entity.DbSet<sp16_p3_g8WebAPI.Models.User> Users { get; set; }
    }
}
