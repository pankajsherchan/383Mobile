using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sp16_p3_g8Web.Models
{
    public class GreatContext : DbContext
    { 
        public GreatContext() : base("name=GreatContext")
        {
            Database.SetInitializer<GreatContext>(new GreatDBInitializer());
        }

        public System.Data.Entity.DbSet<sp16_p3_g8Web.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<sp16_p3_g8Web.Models.Theater> Theaters { get; set; }

        public System.Data.Entity.DbSet<sp16_p3_g8Web.Models.ShowTime> ShowTimes { get; set; }
 
    }
}
