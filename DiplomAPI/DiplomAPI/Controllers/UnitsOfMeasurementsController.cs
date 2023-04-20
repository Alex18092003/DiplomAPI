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
    public class UnitsOfMeasurementsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/UnitsOfMeasurements
        [ResponseType(typeof(List<Models.UnitsOfMeasurementModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.UnitsOfMeasurement.ToList().ConvertAll(x => new Models.UnitsOfMeasurementModel(x)));
        }

        // GET: api/UnitsOfMeasurements/5
        [ResponseType(typeof(UnitsOfMeasurement))]
        public IHttpActionResult GetUnitsOfMeasurement(int id)
        {
            UnitsOfMeasurement unitsOfMeasurement = db.UnitsOfMeasurement.Find(id);
            if (unitsOfMeasurement == null)
            {
                return NotFound();
            }

            return Ok(unitsOfMeasurement);
        }

        // PUT: api/UnitsOfMeasurements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnitsOfMeasurement(int id, UnitsOfMeasurement unitsOfMeasurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unitsOfMeasurement.UnitsOfMeasurementId)
            {
                return BadRequest();
            }

            db.Entry(unitsOfMeasurement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitsOfMeasurementExists(id))
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

        // POST: api/UnitsOfMeasurements
        [ResponseType(typeof(UnitsOfMeasurement))]
        public IHttpActionResult PostUnitsOfMeasurement(UnitsOfMeasurement unitsOfMeasurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UnitsOfMeasurement.Add(unitsOfMeasurement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unitsOfMeasurement.UnitsOfMeasurementId }, unitsOfMeasurement);
        }

        // DELETE: api/UnitsOfMeasurements/5
        [ResponseType(typeof(UnitsOfMeasurement))]
        public IHttpActionResult DeleteUnitsOfMeasurement(int id)
        {
            UnitsOfMeasurement unitsOfMeasurement = db.UnitsOfMeasurement.Find(id);
            if (unitsOfMeasurement == null)
            {
                return NotFound();
            }

            db.UnitsOfMeasurement.Remove(unitsOfMeasurement);
            db.SaveChanges();

            return Ok(unitsOfMeasurement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitsOfMeasurementExists(int id)
        {
            return db.UnitsOfMeasurement.Count(e => e.UnitsOfMeasurementId == id) > 0;
        }
    }
}