namespace FinalWebAPI.Migrations
{
    using APIHelper;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;
    internal sealed class Configuration : DbMigrationsConfiguration<FinalWebAPI.Models.FinalWebAPIContext>
    {
        public static List<Movie> GetMovie()
        {
            MovieAPI1 helper = new MovieAPI1();
            List<Movie> movieList = new List<Movie>();
            movieList = helper.Get();
            return movieList;
        }
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalWebAPI.Models.FinalWebAPIContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            //context.People.AddOrUpdate(
            //  p => p.FullName,
            //  new Person { FullName = "Andrew Peters" },
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);


            context.Users.AddOrUpdate(
               u => u.Id,
               new User { FirstName = "Admin", LastName = "Admin", Email = "383@gmail.com", Role = "Admin", Password = Crypto.HashPassword("password") }

               );

            context.Screens.AddOrUpdate(
               s => s.Id,
               new Screen { ScreenNumber = "100A", SeatCount = 25 },
                new Screen { ScreenNumber = "200A", SeatCount = 25 },
                new Screen { ScreenNumber = "300A", SeatCount = 25 },
                new Screen { ScreenNumber = "400A", SeatCount = 25 },
                new Screen { ScreenNumber = "500A", SeatCount = 25 },
                new Screen { ScreenNumber = "600A", SeatCount = 25 },
                new Screen { ScreenNumber = "700A", SeatCount = 25 },
                new Screen { ScreenNumber = "800A", SeatCount = 25 }
               );


            GetMovie().ForEach(s => context.Movies.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
        }
    }
}
