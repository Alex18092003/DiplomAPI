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
    public class DifficultiesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Difficulties
        [ResponseType(typeof(List<Models.DifficultiesModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Difficulties.ToList().ConvertAll(x => new Models.DifficultiesModel(x)));
        }

        // GET: api/Difficulties/5
        [ResponseType(typeof(Difficulties))]
        public IHttpActionResult GetDifficulties(int id)
        {
            Difficulties difficulties = db.Difficulties.Find(id);
            if (difficulties == null)
            {
                return NotFound();
            }

            return Ok(difficulties);
        }

        // PUT: api/Difficulties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDifficulties(int id, Difficulties difficulties)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != difficulties.DifficultiesId)
            {
                return BadRequest();
            }

            db.Entry(difficulties).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DifficultiesExists(id))
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

        // POST: api/Difficulties
        [ResponseType(typeof(Difficulties))]
        public IHttpActionResult PostDifficulties(Difficulties difficulties)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Difficulties.Add(difficulties);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = difficulties.DifficultiesId }, difficulties);
        }

        // DELETE: api/Difficulties/5
        [ResponseType(typeof(Difficulties))]
        public IHttpActionResult DeleteDifficulties(int id)
        {
            Difficulties difficulties = db.Difficulties.Find(id);
            if (difficulties == null)
            {
                return NotFound();
            }

            db.Difficulties.Remove(difficulties);
            db.SaveChanges();

            return Ok(difficulties);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DifficultiesExists(int id)
        {
            return db.Difficulties.Count(e => e.DifficultiesId == id) > 0;
        }
    }
}