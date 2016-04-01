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
using sp16_p3_g8WebAPI.Models;

namespace sp16_p3_g8WebAPI.Controllers
{
    public class ShowtimesController : ApiController
    {
        private sp16_p3_g8WebAPIContext db = new sp16_p3_g8WebAPIContext();

        // GET: api/Showtimes
        public IQueryable<Showtime> GetShowtimes()
        {
            return db.Showtimes;
        }

        // GET: api/Showtimes/5
        [ResponseType(typeof(Showtime))]
        public IHttpActionResult GetShowtime(int id)
        {
            Showtime showtime = db.Showtimes.Find(id);
            if (showtime == null)
            {
                return NotFound();
            }

            return Ok(showtime);
        }

        // PUT: api/Showtimes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShowtime(int id, Showtime showtime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != showtime.Id)
            {
                return BadRequest();
            }

            db.Entry(showtime).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowtimeExists(id))
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

        // POST: api/Showtimes
        [ResponseType(typeof(Showtime))]
        public IHttpActionResult PostShowtime(Showtime showtime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Showtimes.Add(showtime);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = showtime.Id }, showtime);
        }

        // DELETE: api/Showtimes/5
        [ResponseType(typeof(Showtime))]
        public IHttpActionResult DeleteShowtime(int id)
        {
            Showtime showtime = db.Showtimes.Find(id);
            if (showtime == null)
            {
                return NotFound();
            }

            db.Showtimes.Remove(showtime);
            db.SaveChanges();

            return Ok(showtime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShowtimeExists(int id)
        {
            return db.Showtimes.Count(e => e.Id == id) > 0;
        }
    }
}