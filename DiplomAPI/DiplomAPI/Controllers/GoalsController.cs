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
    public class GoalsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Goals
        [ResponseType(typeof(List<Models.GoalsModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Goals.ToList().ConvertAll(x => new Models.GoalsModel(x)));
        }

        // GET: api/Goals/5
        [ResponseType(typeof(Goals))]
        public IHttpActionResult GetGoals(int id)
        {
            Goals goals = db.Goals.Find(id);
            if (goals == null)
            {
                return NotFound();
            }

            return Ok(goals);
        }

        // PUT: api/Goals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGoals(int id, Goals goals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != goals.GoalId)
            {
                return BadRequest();
            }

            db.Entry(goals).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalsExists(id))
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

        // POST: api/Goals
        [ResponseType(typeof(Goals))]
        public IHttpActionResult PostGoals(Goals goals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Goals.Add(goals);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = goals.GoalId }, goals);
        }

        // DELETE: api/Goals/5
        [ResponseType(typeof(Goals))]
        public IHttpActionResult DeleteGoals(int id)
        {
            Goals goals = db.Goals.Find(id);
            if (goals == null)
            {
                return NotFound();
            }

            db.Goals.Remove(goals);
            db.SaveChanges();

            return Ok(goals);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GoalsExists(int id)
        {
            return db.Goals.Count(e => e.GoalId == id) > 0;
        }
    }
}