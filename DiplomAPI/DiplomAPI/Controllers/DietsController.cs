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
    public class DietsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Diets
        [ResponseType(typeof(List<Models.DietsModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Diets.ToList().ConvertAll(x => new Models.DietsModel(x)));
        }

        // GET: api/Diets/5
        [ResponseType(typeof(Diets))]
        public IHttpActionResult GetDiets(int id)
        {
            Diets diets = db.Diets.Find(id);
            if (diets == null)
            {
                return NotFound();
            }

            return Ok(diets);
        }

        // PUT: api/Diets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiets(int id, Diets diets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diets.DietId)
            {
                return BadRequest();
            }

            db.Entry(diets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietsExists(id))
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

        // POST: api/Diets
        [ResponseType(typeof(Diets))]
        public IHttpActionResult PostDiets(Diets diets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Diets.Add(diets);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = diets.DietId }, diets);
        }

        // DELETE: api/Diets/5
        [ResponseType(typeof(Diets))]
        public IHttpActionResult DeleteDiets(int id)
        {
            Diets diets = db.Diets.Find(id);
            if (diets == null)
            {
                return NotFound();
            }

            db.Diets.Remove(diets);
            db.SaveChanges();

            return Ok(diets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DietsExists(int id)
        {
            return db.Diets.Count(e => e.DietId == id) > 0;
        }
    }
}