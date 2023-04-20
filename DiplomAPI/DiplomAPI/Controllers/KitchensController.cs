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
    public class KitchensController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Kitchens
        [ResponseType(typeof(List<Models.KitchensModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Kitchens.ToList().ConvertAll(x => new Models.KitchensModel(x)));
        }

        // GET: api/Kitchens/5
        [ResponseType(typeof(Kitchens))]
        public IHttpActionResult GetKitchens(int id)
        {
            Kitchens kitchens = db.Kitchens.Find(id);
            if (kitchens == null)
            {
                return NotFound();
            }

            return Ok(kitchens);
        }

        // PUT: api/Kitchens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKitchens(int id, Kitchens kitchens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kitchens.KitchenId)
            {
                return BadRequest();
            }

            db.Entry(kitchens).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitchensExists(id))
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

        // POST: api/Kitchens
        [ResponseType(typeof(Kitchens))]
        public IHttpActionResult PostKitchens(Kitchens kitchens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kitchens.Add(kitchens);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kitchens.KitchenId }, kitchens);
        }

        // DELETE: api/Kitchens/5
        [ResponseType(typeof(Kitchens))]
        public IHttpActionResult DeleteKitchens(int id)
        {
            Kitchens kitchens = db.Kitchens.Find(id);
            if (kitchens == null)
            {
                return NotFound();
            }

            db.Kitchens.Remove(kitchens);
            db.SaveChanges();

            return Ok(kitchens);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KitchensExists(int id)
        {
            return db.Kitchens.Count(e => e.KitchenId == id) > 0;
        }
    }
}