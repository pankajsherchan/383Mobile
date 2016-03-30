using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable.Serializers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using sp16_p3_g8Web.Models;

namespace sp16_p3_g8Web.Controllers
{
    public class MoviesAPIController : ApiController
    {
        private GreatContext dbc = new GreatContext();
        private readonly RestClient client = new RestClient("http://omdbapi.com/?");

        // GET: api/Movies
        public async Task<List<T>> Get<T>(string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            var response = await client.Execute<List<T>>(request);
            return response.Data;
        }

        public IQueryable<Movie> GetMoviesByDB()
        {
            return dbc.Movies;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetMovieName(string title)
        {
            Movie film = await dbc.Movies.FindAsync(title);
            if (film == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            return Ok(film);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> PostMovie(Movie film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbc.Movies.Add(film);
            await dbc.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = film.ID }, film);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItem(int id, Movie film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != film.ID)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            dbc.Entry(film).State = EntityState.Modified;

            try
            {
                await dbc.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            Movie film = await dbc.Movies.FindAsync(id);
            if (film != null)
            {
                dbc.Movies.Remove(film);
                await dbc.SaveChangesAsync();
            }
            else
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            return Ok(film);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbc.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmExists(int id)
        {
            return dbc.Movies.Count(p => p.ID == id) > 0;
        }
    }
}
