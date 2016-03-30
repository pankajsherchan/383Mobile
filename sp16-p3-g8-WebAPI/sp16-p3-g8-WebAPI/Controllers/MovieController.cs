using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using sp16_p3_g8_WebAPI.Models;
using sp16_p3_g8_WebAPI.Service;
using sp16_p3_g8_WebAPI.DTO_Service;

namespace sp16_p3_g8_WebAPI.Controllers
{
    public class MovieController : ApiController
    {
        
        MovieRepo repo = new MovieRepo();
        DTOFactory _factory = new DTOFactory();

        // GET: api/movies
        public IEnumerable<MovieDTO> Getmovies()
        {
            var moviesList = new List<MovieDTO>();
            var List = repo.Getmovies();

            foreach(var item in List)
            {
                moviesList.Add(_factory.createMoviesDTO(item));
            }
            return moviesList;
        }

        // GET: api/movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult Getmovies(int id)
        {
           Movie movies = repo.Getmovies(id);

            if (movies == null)
            {
                return NotFound();
            }

            var factorymovie = _factory.createMoviesDTO(movies);
            return Ok(factorymovie);
        }

        // PUT: api/movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmovies(int id, Movie movies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movies.moviesId)
            {
                return BadRequest();
            }

            repo.Putmovies(movies);

            try
            {
                repo.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!moviesExists(id))
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

        // POST: api/movies
        [ResponseType(typeof(Movie))]
        public IHttpActionResult Postmovies(Movie movies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Postmovies(movies);
            repo.save();

            return CreatedAtRoute("DefaultApi", new { id = movies.moviesId }, _factory.createMoviesDTO(movies));
        }

        // DELETE: api/movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult Deletemovies(int id)
        {
            bool value = repo.Deletemovies(id);
            if (value == false)
            {
                return NotFound();
            }
            else {

                return Ok();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.dispose();
            }
            base.Dispose(disposing);
        }

        private bool moviesExists(int id)
        {
            return repo.moviesExists(id);
        }
    }
}