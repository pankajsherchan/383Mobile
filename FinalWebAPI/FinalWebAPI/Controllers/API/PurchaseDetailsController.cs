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
using FinalWebAPI.APIHelper;

namespace FinalWebAPI.Controllers.API
{
    public class PurchaseDetailsController : ApiController
    {
        private FinalWebAPIContext db = new FinalWebAPIContext();

        // GET: api/PurchaseDetails
        public IQueryable<PurchaseDetail> GetPurchaseDetails()
        {
            return db.PurchaseDetails;
        }

        // GET: api/PurchaseDetails/5
        [ResponseType(typeof(PurchaseDetail))]
        public IHttpActionResult GetPurchaseDetail(int id)
        {
            PurchaseDetail purchaseDetail = db.PurchaseDetails.Find(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return Ok(purchaseDetail);
        }


        [AllowAnonymous]
        [System.Web.Http.ActionName("Update")]
        public HttpResponseMessage Update(string email, List<PurchaseDTO> movies)
        {



            PurchaseDetail purchased = new PurchaseDetail();

            foreach (var item in movies)
            {
                //product = db.Products.Find(item.ProductId);
                //product.InventoryCount = product.InventoryCount - item.InventoryCount;
                purchased.InventoryCount = item.InventoryCount;
                purchased.Price = item.Price;
                purchased.type = item.type;
                purchased.Name = item.Name;
                purchased.ScreenNumber = item.ScreenNumber;
                purchased.time = item.time;
                purchased.date = DateTime.Today.ToString();

                db.PurchaseDetails.Add(purchased);


               
                

            try
            {
                    db.SaveChanges();
                    Gmailer mail = new Gmailer();
            mail.sendEmail(email, movies);


                }

                catch (DbUpdateConcurrencyException)
                {
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        //    //foreach (var movie in movies)
        //    //{
        //    //    var purchase = new PurchaseDetail
        //    //    {
        //    //        InventoryCount = movie.InventoryCount,
        //    //        Price = movie.Price,
        //    //        type = movie.type,
        //    //        Name = movie.Name,
        //    //        ScreenNumber = movie.ScreenNumber,
        //    //        time = movie.time,
        //    //        date = DateTime.Today.ToString()


        //    //    };
        //    //    db.PurchaseDetails.Add(purchase);
        //    //    db.SaveChanges();
        //    //}


        //    //    return CreatedAtRoute("DefaultApi", purchase);
        //    //}
        //    //return null;

        //}











        // PUT: api/PurchaseDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPurchaseDetail(int id, PurchaseDetail purchaseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(purchaseDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseDetailExists(id))
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

        // POST: api/PurchaseDetails
        [ResponseType(typeof(PurchaseDetail))]
        public IHttpActionResult PostPurchaseDetail(PurchaseDetail purchaseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseDetails.Add(purchaseDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = purchaseDetail.Id }, purchaseDetail);
        }

        // DELETE: api/PurchaseDetails/5
        [ResponseType(typeof(PurchaseDetail))]
        public IHttpActionResult DeletePurchaseDetail(int id)
        {
            PurchaseDetail purchaseDetail = db.PurchaseDetails.Find(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            db.PurchaseDetails.Remove(purchaseDetail);
            db.SaveChanges();

            return Ok(purchaseDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseDetailExists(int id)
        {
            return db.PurchaseDetails.Count(e => e.Id == id) > 0;
        }
    }
}