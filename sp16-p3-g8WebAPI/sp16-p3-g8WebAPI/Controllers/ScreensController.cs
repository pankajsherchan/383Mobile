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
    public class ScreensController : ApiController
    {
        private sp16_p3_g8WebAPIContext db = new sp16_p3_g8WebAPIContext();

        // GET: api/Screens
        public IQueryable<Screen> GetScreens()
        {
            return db.Screens;
        }

        // GET: api/Screens/5
        [ResponseType(typeof(Screen))]
        public IHttpActionResult GetScreen(int id)
        {
            Screen screen = db.Screens.Find(id);
            if (screen == null)
            {
                return NotFound();
            }

            return Ok(screen);
        }

        // PUT: api/Screens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutScreen(int id, Screen screen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != screen.Id)
            {
                return BadRequest();
            }

            db.Entry(screen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreenExists(id))
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

        // POST: api/Screens
        [ResponseType(typeof(Screen))]
        public IHttpActionResult PostScreen(Screen screen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Screens.Add(screen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = screen.Id }, screen);
        }

        // DELETE: api/Screens/5
        [ResponseType(typeof(Screen))]
        public IHttpActionResult DeleteScreen(int id)
        {
            Screen screen = db.Screens.Find(id);
            if (screen == null)
            {
                return NotFound();
            }

            db.Screens.Remove(screen);
            db.SaveChanges();

            return Ok(screen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScreenExists(int id)
        {
            return db.Screens.Count(e => e.Id == id) > 0;
        }
    }
}