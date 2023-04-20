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
    public class IngredientsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Ingredients
        [ResponseType(typeof(List<Models.IngredientsModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Ingredients.ToList().ConvertAll(x => new Models.IngredientsModel(x)));
        }

        // GET: api/Ingredients/5
        [ResponseType(typeof(Ingredients))]
        public IHttpActionResult GetIngredients(int id)
        {
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            return Ok(ingredients);
        }

        // PUT: api/Ingredients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngredients(int id, Ingredients ingredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredients.IngredientId)
            {
                return BadRequest();
            }

            db.Entry(ingredients).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientsExists(id))
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

        // POST: api/Ingredients
        [ResponseType(typeof(Ingredients))]
        public IHttpActionResult PostIngredients(Ingredients ingredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingredients.Add(ingredients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingredients.IngredientId }, ingredients);
        }

        // DELETE: api/Ingredients/5
        [ResponseType(typeof(Ingredients))]
        public IHttpActionResult DeleteIngredients(int id)
        {
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            db.Ingredients.Remove(ingredients);
            db.SaveChanges();

            return Ok(ingredients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientsExists(int id)
        {
            return db.Ingredients.Count(e => e.IngredientId == id) > 0;
        }
    }
}