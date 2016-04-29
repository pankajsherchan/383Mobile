using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalWebAPI.Models
{
    public class FinalWebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FinalWebAPIContext() : base("name=FinalWebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<FinalWebAPI.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<FinalWebAPI.Models.Screen> Screens { get; set; }

        public System.Data.Entity.DbSet<FinalWebAPI.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<FinalWebAPI.Models.Showtime> Showtimes { get; set; }

        public System.Data.Entity.DbSet<FinalWebAPI.Models.PurchaseTicket> PurchaseTickets { get; set; }

        public System.Data.Entity.DbSet<FinalWebAPI.Models.PurchaseTicketLineItem> PurchaseTicketLineItems { get; set; }
    }
}
