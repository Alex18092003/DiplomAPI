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
    public class MealsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Meals
        [ResponseType(typeof(List<Models.MealsModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Meals.ToList().ConvertAll(x => new Models.MealsModel(x)));
        }

        // GET: api/Meals/5
        [ResponseType(typeof(Meals))]
        public IHttpActionResult GetMeals(int id)
        {
            Meals meals = db.Meals.Find(id);
            if (meals == null)
            {
                return NotFound();
            }

            return Ok(meals);
        }

        // PUT: api/Meals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeals(int id, Meals meals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meals.MealId)
            {
                return BadRequest();
            }

            db.Entry(meals).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealsExists(id))
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

        // POST: api/Meals
        [ResponseType(typeof(Meals))]
        public IHttpActionResult PostMeals(Meals meals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Meals.Add(meals);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meals.MealId }, meals);
        }

        // DELETE: api/Meals/5
        [ResponseType(typeof(Meals))]
        public IHttpActionResult DeleteMeals(int id)
        {
            Meals meals = db.Meals.Find(id);
            if (meals == null)
            {
                return NotFound();
            }

            db.Meals.Remove(meals);
            db.SaveChanges();

            return Ok(meals);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MealsExists(int id)
        {
            return db.Meals.Count(e => e.MealId == id) > 0;
        }
    }
}