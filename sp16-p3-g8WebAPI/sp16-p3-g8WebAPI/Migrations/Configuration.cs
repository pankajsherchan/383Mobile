namespace sp16_p3_g8WebAPI.Migrations
{
    using APIHelper;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;
    internal sealed class Configuration : DbMigrationsConfiguration<sp16_p3_g8WebAPI.Models.sp16_p3_g8WebAPIContext>
    {

        public static List<Movie> GetMovie()
        {
            MovieAPI helper = new MovieAPI();
            List<Movie> movieList = new List<Movie>();
            movieList = helper.GetMovie();
            return movieList;
        }
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;



        }

        protected override void Seed(sp16_p3_g8WebAPI.Models.sp16_p3_g8WebAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Users.AddOrUpdate(
            //    u => u.Id,
            //    new User { FirstName = "Admin", LastName = "Admin", Email = "383@gmail.com", Role = "Admin", Password = Crypto.HashPassword("password") }

            //    );
            //   var movie = GetMovie();
            GetMovie().ForEach(s => context.Movies.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            //  context.Movies.AddOrUpdate

            //context.Movies.AddOrUpdate(
            //    m => m.Id,
            //    new Movie { Name = "Movie1", Description = "this is a nice movie", Duration = "120 minutes", Rating = 9, ReleaseDate= DateTime.Today, Cast = "faklsjlfa" },
            //     new Movie { Name = "Movie2", Description = "this is a nice movie second", Duration = "180 minutes", Rating = 8, ReleaseDate = DateTime.Today, Cast = "fkasjkl" }
            //    );

            context.Screens.AddOrUpdate(
               m => m.Id,
               new Screen { ScreenNumber = "100A", SeatCount = 25 },
                new Screen { ScreenNumber = "200A", SeatCount = 25 },
                new Screen { ScreenNumber ="300A", SeatCount =25},
                new Screen { ScreenNumber ="400A", SeatCount =25}
               );


            //context.Showtimes.AddOrUpdate(
            //  m => m.Id,
            //  new Showtime { MovieId = 3, ScreenId = 3, StartDateTime = DateTime.Today }
            //  );

        }
    }
}