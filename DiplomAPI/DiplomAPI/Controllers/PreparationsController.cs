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
    public class PreparationsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Preparations
        [ResponseType(typeof(List<Models.PreparationsModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Preparations.ToList().ConvertAll(x => new Models.PreparationsModel(x)));
        }

        // GET: api/Preparations/5
        [ResponseType(typeof(Preparations))]
        public IHttpActionResult GetPreparations(int id)
        {
            Preparations preparations = db.Preparations.Find(id);
            if (preparations == null)
            {
                return NotFound();
            }

            return Ok(preparations);
        }

        // PUT: api/Preparations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPreparations(int id, Preparations preparations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preparations.PreparationId)
            {
                return BadRequest();
            }

            db.Entry(preparations).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreparationsExists(id))
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

        // POST: api/Preparations
        [ResponseType(typeof(Preparations))]
        public IHttpActionResult PostPreparations(Preparations preparations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Preparations.Add(preparations);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = preparations.PreparationId }, preparations);
        }

        // DELETE: api/Preparations/5
        [ResponseType(typeof(Preparations))]
        public IHttpActionResult DeletePreparations(int id)
        {
            Preparations preparations = db.Preparations.Find(id);
            if (preparations == null)
            {
                return NotFound();
            }

            db.Preparations.Remove(preparations);
            db.SaveChanges();

            return Ok(preparations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreparationsExists(int id)
        {
            return db.Preparations.Count(e => e.PreparationId == id) > 0;
        }
    }
}