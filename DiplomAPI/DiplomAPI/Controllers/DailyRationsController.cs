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
using DiplomAPI;

namespace DiplomAPI.Controllers
{
    public class DailyRationsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/DailyRations
        [ResponseType(typeof(List<Models.DailyRationModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.DailyRation.ToList().ConvertAll(x => new Models.DailyRationModel(x)));
        }

        // GET: api/DailyRations/5
        [ResponseType(typeof(DailyRation))]
        public IHttpActionResult GetDailyRation(int id)
        {
            DailyRation dailyRation = db.DailyRation.Find(id);
            if (dailyRation == null)
            {
                return NotFound();
            }

            return Ok(dailyRation);
        }

        // PUT: api/DailyRations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDailyRation(int id, DailyRation dailyRation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dailyRation.DailyRationId)
            {
                return BadRequest();
            }

            db.Entry(dailyRation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyRationExists(id))
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

        // POST: api/DailyRations
        [ResponseType(typeof(DailyRation))]
        public IHttpActionResult PostDailyRation(DailyRation dailyRation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DailyRation.Add(dailyRation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dailyRation.DailyRationId }, dailyRation);
        }

        // DELETE: api/DailyRations/5
        [ResponseType(typeof(DailyRation))]
        public IHttpActionResult DeleteDailyRation(int id)
        {
            DailyRation dailyRation = db.DailyRation.Find(id);
            if (dailyRation == null)
            {
                return NotFound();
            }

            db.DailyRation.Remove(dailyRation);
            db.SaveChanges();

            return Ok(dailyRation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DailyRationExists(int id)
        {
            return db.DailyRation.Count(e => e.DailyRationId == id) > 0;
        }
    }
}