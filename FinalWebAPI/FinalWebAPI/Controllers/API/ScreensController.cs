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

namespace FinalWebAPI.Controllers.API
{
    public class ScreensController : ApiController
    {
        private FinalWebAPIContext db = new FinalWebAPIContext();

        // GET: api/Screens
        public IQueryable<Screen> GetScreens()
        {
            return db.Screens;
        }

        // GET: api/Screens/5
        [ResponseType(typeof(Screen))]
        public async Task<IHttpActionResult> GetScreen(int id)
        {
            Screen screen = await db.Screens.FindAsync(id);
            if (screen == null)
            {
                return NotFound();
            }

            return Ok(screen);
        }

        // PUT: api/Screens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutScreen(int id, Screen screen)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostScreen(Screen screen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Screens.Add(screen);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = screen.Id }, screen);
        }

        // DELETE: api/Screens/5
        [ResponseType(typeof(Screen))]
        public async Task<IHttpActionResult> DeleteScreen(int id)
        {
            Screen screen = await db.Screens.FindAsync(id);
            if (screen == null)
            {
                return NotFound();
            }

            db.Screens.Remove(screen);
            await db.SaveChangesAsync();

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