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
    public class StepsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Steps
        [ResponseType(typeof(List<Models.StepsModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Steps.ToList().ConvertAll(x => new Models.StepsModel(x)));
        }

        // GET: api/Steps/5
        [ResponseType(typeof(Steps))]
        public IHttpActionResult GetSteps(int id)
        {
            Steps steps = db.Steps.Find(id);
            if (steps == null)
            {
                return NotFound();
            }

            return Ok(steps);
        }

        // PUT: api/Steps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSteps(int id, Steps steps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != steps.StepId)
            {
                return BadRequest();
            }

            db.Entry(steps).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepsExists(id))
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

        // POST: api/Steps
        [ResponseType(typeof(Steps))]
        public IHttpActionResult PostSteps(Steps steps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Steps.Add(steps);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = steps.StepId }, steps);
        }

        // DELETE: api/Steps/5
        [ResponseType(typeof(Steps))]
        public IHttpActionResult DeleteSteps(int id)
        {
            Steps steps = db.Steps.Find(id);
            if (steps == null)
            {
                return NotFound();
            }

            db.Steps.Remove(steps);
            db.SaveChanges();

            return Ok(steps);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StepsExists(int id)
        {
            return db.Steps.Count(e => e.StepId == id) > 0;
        }
    }
}