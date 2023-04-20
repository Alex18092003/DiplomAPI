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
    public class IngredientForRecipesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/IngredientForRecipes
        [ResponseType(typeof(List<Models.IngredientForRecipeModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.IngredientForRecipe.ToList().ConvertAll(x => new Models.IngredientForRecipeModel(x)));
        }

        // GET: api/IngredientForRecipes/5
        [ResponseType(typeof(IngredientForRecipe))]
        public IHttpActionResult GetIngredientForRecipe(int id)
        {
            IngredientForRecipe ingredientForRecipe = db.IngredientForRecipe.Find(id);
            if (ingredientForRecipe == null)
            {
                return NotFound();
            }

            return Ok(ingredientForRecipe);
        }

        // PUT: api/IngredientForRecipes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngredientForRecipe(int id, IngredientForRecipe ingredientForRecipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredientForRecipe.IngredientForRecipeId)
            {
                return BadRequest();
            }

            db.Entry(ingredientForRecipe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientForRecipeExists(id))
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

        // POST: api/IngredientForRecipes
        [ResponseType(typeof(IngredientForRecipe))]
        public IHttpActionResult PostIngredientForRecipe(IngredientForRecipe ingredientForRecipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IngredientForRecipe.Add(ingredientForRecipe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingredientForRecipe.IngredientForRecipeId }, ingredientForRecipe);
        }

        // DELETE: api/IngredientForRecipes/5
        [ResponseType(typeof(IngredientForRecipe))]
        public IHttpActionResult DeleteIngredientForRecipe(int id)
        {
            IngredientForRecipe ingredientForRecipe = db.IngredientForRecipe.Find(id);
            if (ingredientForRecipe == null)
            {
                return NotFound();
            }

            db.IngredientForRecipe.Remove(ingredientForRecipe);
            db.SaveChanges();

            return Ok(ingredientForRecipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientForRecipeExists(int id)
        {
            return db.IngredientForRecipe.Count(e => e.IngredientForRecipeId == id) > 0;
        }
    }
}