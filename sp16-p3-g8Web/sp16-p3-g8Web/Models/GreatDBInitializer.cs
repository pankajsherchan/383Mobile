using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using sp16_p3_g8Web.Models;

namespace sp16_p3_g8Web.Models
{
    public class GreatDBInitializer : DropCreateDatabaseAlways<GreatContext>
    {
        protected override void Seed(GreatContext context)
        {
            List<Movie> films = new List<Movie>
            {
                //Stuff Request In here?
            };
            foreach (var film in films)
            {
                context.Movies.Add(film);
            }
            
            base.Seed(context);
        }
    }
}