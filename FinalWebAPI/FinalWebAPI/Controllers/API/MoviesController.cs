using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using FinalWebAPI.Models;
using FinalWebAPI.Models.DTOs;

namespace FinalWebAPI.Controllers.API
{
    public class MoviesController : ApiController
    {
        private FinalWebAPIContext db = new FinalWebAPIContext();

        // GET: api/Movies
        //public IQueryable<Movie> GetMovies()
        //{
        //    return db.Movies;
        //}

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet]
        [ActionName("Showing")]
        public IHttpActionResult Get()
        {

            //            List<ShowingDTO> showingMovies = new List<ShowingDTO>();


            //List<ShowingDTO> showingMovies = (from c in db.Movies
            //                                  select new ShowingDTO()
            //                                  {
            //                                      Id = c.Id,
            //                                      Name = c.Name,
            //                                      Year = c.Year,
            //                                      showtimes = (from p in db.Showtimes where (p.MovieId == c.Id && p.StartDate == DateTime.Today) select p).ToList<Showtime>()
            //                                  }).ToList<ShowingDTO>();


            List<ShowingDTO> showingMovies =
            db.Movies.Where(x => x.Showtimes.Any(y => y.StartDate == DateTime.Today)).Select(x => new ShowingDTO
            {

                //StartTime = (from p in db.Showtimes where (p.MovieId == x.Id) select p.StartTime).ToList<string>(),
                Id = x.Id,
                Poster = x.Poster,
                Duration = x.Duration,
                Genre = x.Genre,
                Name = x.Name,
                Year = x.Year,
                Description = x.Description,
                showtimes = x.Showtimes.ToList<Showtime>()

            }).ToList<ShowingDTO>();

            if (showingMovies == null)
            {

                return NotFound();
            }


            return Ok(showingMovies);
        }

        

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }

    }
}