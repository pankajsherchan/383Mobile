using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWebAPI.Models;
using FinalWebAPI.APIHelper;

namespace FinalWebAPI.Controllers.MVC
{
    
    public class ShowtimesController : Controller
    {
        private FinalWebAPIContext db = new FinalWebAPIContext();

        CheckRole check = new CheckRole();
        // GET: Showtimes
        public ActionResult Index()
        {
            var showtimes = db.Showtimes.Include(s => s.Movie).Include(s => s.Screen);
            return View(showtimes.ToList());
        }

        // GET: Showtimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = db.Showtimes.Find(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            return View(showtime);
        }

        [Authorize]
        // GET: Showtimes/Create
        public ActionResult Create()
        {
            if (check.GetUser().Role == "Admin")
            {
                ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name");
                ViewBag.ScreenId = new SelectList(db.Screens, "Id", "ScreenNumber");
                return View();


            }
            else {
                ModelState.AddModelError("badlogin", "Username or Password is Incorrect! Please try Again!!");
                ViewBag.Message = "YOU ARE NOT AUTHORIZED";

            }
            return View(check.GetUser());






        }

        // POST: Showtimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ScreenId,MovieId,StartDate,StartTime")] Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                db.Showtimes.Add(showtime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", showtime.MovieId);
            ViewBag.ScreenId = new SelectList(db.Screens, "Id", "ScreenNumber", showtime.ScreenId);
            return View(showtime);
        }

        // GET: Showtimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = db.Showtimes.Find(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", showtime.MovieId);
            ViewBag.ScreenId = new SelectList(db.Screens, "Id", "ScreenNumber", showtime.ScreenId);
            return View(showtime);
        }

        // POST: Showtimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ScreenId,MovieId,StartDateTime")] Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showtime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", showtime.MovieId);
            ViewBag.ScreenId = new SelectList(db.Screens, "Id", "ScreenNumber", showtime.ScreenId);
            return View(showtime);
        }

        // GET: Showtimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = db.Showtimes.Find(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            return View(showtime);
        }

        // POST: Showtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Showtime showtime = db.Showtimes.Find(id);
            db.Showtimes.Remove(showtime);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool GetRole(User user) {


            return true;
        }
    }
}
