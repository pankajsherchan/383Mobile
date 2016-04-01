namespace sp16_p3_g8WebAPI.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<sp16_p3_g8WebAPI.Models.sp16_p3_g8WebAPIContext>
    {
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

            context.Movies.AddOrUpdate(
                m => m.Id,
                new Movie { Name = "Movie1", Description = "this is a nice movie", Duration = "120 minutes", Rating = 9, ReleaseDate= DateTime.Today, Cast = "faklsjlfa" },
                 new Movie { Name = "Movie2", Description = "this is a nice movie second", Duration = "180 minutes", Rating = 8, ReleaseDate = DateTime.Today, Cast = "fkasjkl" }
                );

            context.Screens.AddOrUpdate(
               m => m.Id,
               new Screen { ScreenNumber = 1, SeatCount = 25 },
                new Screen { ScreenNumber = 2, SeatCount = 25 }
               );


            context.Showtimes.AddOrUpdate(
              m => m.Id,
              new Showtime { MovieId = 11, ScreenId = 5, StartDateTime = DateTime.Today}
              );

        }
    }
}
