using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sp16_p3_g8_WebAPI.Models
{
    public class sp16_p3_g8_WebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public sp16_p3_g8_WebAPIContext() : base("name=sp16_p3_g8_WebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<sp16_p3_g8_WebAPI.Models.Movie> movies { get; set; }
    }
}
