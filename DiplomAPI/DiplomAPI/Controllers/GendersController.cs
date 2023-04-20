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
    public class GendersController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Genders
        [ResponseType(typeof(List<Models.GendersModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Genders.ToList().ConvertAll(x => new Models.GendersModel(x)));
        }

        // GET: api/Genders/5
        [ResponseType(typeof(Genders))]
        public IHttpActionResult GetGenders(int id)
        {
            Genders genders = db.Genders.Find(id);
            if (genders == null)
            {
                return NotFound();
            }

            return Ok(genders);
        }

        // PUT: api/Genders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenders(int id, Genders genders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genders.GenderId)
            {
                return BadRequest();
            }

            db.Entry(genders).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GendersExists(id))
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

        // POST: api/Genders
        [ResponseType(typeof(Genders))]
        public IHttpActionResult PostGenders(Genders genders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Genders.Add(genders);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = genders.GenderId }, genders);
        }

        // DELETE: api/Genders/5
        [ResponseType(typeof(Genders))]
        public IHttpActionResult DeleteGenders(int id)
        {
            Genders genders = db.Genders.Find(id);
            if (genders == null)
            {
                return NotFound();
            }

            db.Genders.Remove(genders);
            db.SaveChanges();

            return Ok(genders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GendersExists(int id)
        {
            return db.Genders.Count(e => e.GenderId == id) > 0;
        }
    }
}