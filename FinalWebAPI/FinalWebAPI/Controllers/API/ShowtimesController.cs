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
using System.Threading.Tasks;
using FinalWebAPI.Models;

namespace FinalWebAPI.Controllers.API
{
    public class ShowtimesController : ApiController
    {
        private FinalWebAPIContext db = new FinalWebAPIContext();

        // GET: api/Showtimes
        public IQueryable<Showtime> GetShowtimes()
        {
            return db.Showtimes;
        }

        // GET: api/Showtimes/5
        [ResponseType(typeof(Showtime))]
        public async Task<IHttpActionResult> GetShowtime(int id)
        {
            Showtime showtime = await db.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                return NotFound();
            }

            return Ok(showtime);
        }

        // PUT: api/Showtimes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShowtime(int id, Showtime showtime)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostShowtime(Showtime showtime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Showtimes.Add(showtime);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = showtime.Id }, showtime);
        }

        // DELETE: api/Showtimes/5
        [ResponseType(typeof(Showtime))]
        public async Task<IHttpActionResult> DeleteShowtime(int id)
        {
            Showtime showtime = await db.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                return NotFound();
            }

            db.Showtimes.Remove(showtime);
            await db.SaveChangesAsync();

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