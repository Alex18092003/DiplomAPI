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
    public class RecipesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Recipes
        [ResponseType(typeof(List<Models.RecipesModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Recipes.ToList().ConvertAll(x => new Models.RecipesModel(x)));
        }

        // GET: api/Recipes/5
        [ResponseType(typeof(Recipes))]
        public IHttpActionResult GetRecipes(int id)
        {
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        // PUT: api/Recipes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipes(int id, Recipes recipes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipes.RecipeId)
            {
                return BadRequest();
            }

            db.Entry(recipes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipesExists(id))
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

        // POST: api/Recipes
        [ResponseType(typeof(Recipes))]
        public IHttpActionResult PostRecipes(Recipes recipes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipes.Add(recipes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipes.RecipeId }, recipes);
        }

        // DELETE: api/Recipes/5
        [ResponseType(typeof(Recipes))]
        public IHttpActionResult DeleteRecipes(int id)
        {
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(recipes);
            db.SaveChanges();

            return Ok(recipes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipesExists(int id)
        {
            return db.Recipes.Count(e => e.RecipeId == id) > 0;
        }
    }
}