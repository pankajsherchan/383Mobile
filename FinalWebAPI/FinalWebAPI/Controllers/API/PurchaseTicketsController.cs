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
using FinalWebAPI.Models;
using FinalWebAPI.Models.DTOs;

namespace FinalWebAPI.Controllers.API
{
    public class PurchaseTicketsController : ApiController
    {
        private FinalWebAPIContext db = new FinalWebAPIContext();

        // GET: api/PurchaseTickets
        //public IQueryable<PurchaseTicket> GetPurchaseTickets()
        //{
        //    return db.PurchaseTickets;
        //}

        // GET: api/PurchaseTickets/5
        //[ResponseType(typeof(PurchaseTicket))]
        //public IHttpActionResult GetPurchaseTicket(int id)
        //{
        //    PurchaseTicket purchaseTicket = db.PurchaseTickets.Find(id);
        //    if (purchaseTicket == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(purchaseTicket);
        //}


        //public HttpResponseMessage UpdateProducts([FromUri]string email, List<Product> products)
        //{
       // [HttpPost]
      
        // PUT: api/PurchaseTickets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPurchaseTicket(int id, PurchaseTicket purchaseTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseTicket.Id)
            {
                return BadRequest();
            }

            db.Entry(purchaseTicket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseTicketExists(id))
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

        // POST: api/PurchaseTickets
        [ResponseType(typeof(PurchaseTicket))]
        public IHttpActionResult PostPurchaseTicket(PurchaseTicket purchaseTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseTickets.Add(purchaseTicket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = purchaseTicket.Id }, purchaseTicket);
        }

        // DELETE: api/PurchaseTickets/5
        [ResponseType(typeof(PurchaseTicket))]
        public IHttpActionResult DeletePurchaseTicket(int id)
        {
            PurchaseTicket purchaseTicket = db.PurchaseTickets.Find(id);
            if (purchaseTicket == null)
            {
                return NotFound();
            }

            db.PurchaseTickets.Remove(purchaseTicket);
            db.SaveChanges();

            return Ok(purchaseTicket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseTicketExists(int id)
        {
            return db.PurchaseTickets.Count(e => e.Id == id) > 0;
        }
    }
}