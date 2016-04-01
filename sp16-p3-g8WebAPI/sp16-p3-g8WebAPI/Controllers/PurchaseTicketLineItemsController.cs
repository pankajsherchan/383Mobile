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
    public class PurchaseTicketLineItemsController : ApiController
    {
        private sp16_p3_g8WebAPIContext db = new sp16_p3_g8WebAPIContext();

        // GET: api/PurchaseTicketLineItems
        public IQueryable<PurchaseTicketLineItem> GetPurchaseTicketLineItems()
        {
            return db.PurchaseTicketLineItems;
        }

        // GET: api/PurchaseTicketLineItems/5
        [ResponseType(typeof(PurchaseTicketLineItem))]
        public IHttpActionResult GetPurchaseTicketLineItem(int id)
        {
            PurchaseTicketLineItem purchaseTicketLineItem = db.PurchaseTicketLineItems.Find(id);
            if (purchaseTicketLineItem == null)
            {
                return NotFound();
            }

            return Ok(purchaseTicketLineItem);
        }

        // PUT: api/PurchaseTicketLineItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPurchaseTicketLineItem(int id, PurchaseTicketLineItem purchaseTicketLineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseTicketLineItem.Id)
            {
                return BadRequest();
            }

            db.Entry(purchaseTicketLineItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseTicketLineItemExists(id))
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

        // POST: api/PurchaseTicketLineItems
        [ResponseType(typeof(PurchaseTicketLineItem))]
        public IHttpActionResult PostPurchaseTicketLineItem(PurchaseTicketLineItem purchaseTicketLineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseTicketLineItems.Add(purchaseTicketLineItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = purchaseTicketLineItem.Id }, purchaseTicketLineItem);
        }

        // DELETE: api/PurchaseTicketLineItems/5
        [ResponseType(typeof(PurchaseTicketLineItem))]
        public IHttpActionResult DeletePurchaseTicketLineItem(int id)
        {
            PurchaseTicketLineItem purchaseTicketLineItem = db.PurchaseTicketLineItems.Find(id);
            if (purchaseTicketLineItem == null)
            {
                return NotFound();
            }

            db.PurchaseTicketLineItems.Remove(purchaseTicketLineItem);
            db.SaveChanges();

            return Ok(purchaseTicketLineItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseTicketLineItemExists(int id)
        {
            return db.PurchaseTicketLineItems.Count(e => e.Id == id) > 0;
        }
    }
}