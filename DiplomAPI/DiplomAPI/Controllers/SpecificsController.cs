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
    public class SpecificsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Specifics
        [ResponseType(typeof(List<Models.SpecificsModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Specifics.ToList().ConvertAll(x => new Models.SpecificsModel(x)));
        }

        // GET: api/Specifics/5
        [ResponseType(typeof(Specifics))]
        public IHttpActionResult GetSpecifics(int id)
        {
            Specifics specifics = db.Specifics.Find(id);
            if (specifics == null)
            {
                return NotFound();
            }

            return Ok(specifics);
        }

        // PUT: api/Specifics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpecifics(int id, Specifics specifics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specifics.SpecificityId)
            {
                return BadRequest();
            }

            db.Entry(specifics).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecificsExists(id))
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

        // POST: api/Specifics
        [ResponseType(typeof(Specifics))]
        public IHttpActionResult PostSpecifics(Specifics specifics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specifics.Add(specifics);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = specifics.SpecificityId }, specifics);
        }

        // DELETE: api/Specifics/5
        [ResponseType(typeof(Specifics))]
        public IHttpActionResult DeleteSpecifics(int id)
        {
            Specifics specifics = db.Specifics.Find(id);
            if (specifics == null)
            {
                return NotFound();
            }

            db.Specifics.Remove(specifics);
            db.SaveChanges();

            return Ok(specifics);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecificsExists(int id)
        {
            return db.Specifics.Count(e => e.SpecificityId == id) > 0;
        }
    }
}