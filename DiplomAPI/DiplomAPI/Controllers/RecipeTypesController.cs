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
    public class RecipeTypesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/RecipeTypes
        [ResponseType(typeof(List<Models.RecipeTypesModel>))]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.RecipeTypes.ToList().ConvertAll(x => new Models.RecipeTypesModel(x)));
        }

        // GET: api/RecipeTypes/5
        [ResponseType(typeof(RecipeTypes))]
        public IHttpActionResult GetRecipeTypes(int id)
        {
            RecipeTypes recipeTypes = db.RecipeTypes.Find(id);
            if (recipeTypes == null)
            {
                return NotFound();
            }

            return Ok(recipeTypes);
        }

        // PUT: api/RecipeTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipeTypes(int id, RecipeTypes recipeTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeTypes.RecipeTypeId)
            {
                return BadRequest();
            }

            db.Entry(recipeTypes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeTypesExists(id))
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

        // POST: api/RecipeTypes
        [ResponseType(typeof(RecipeTypes))]
        public IHttpActionResult PostRecipeTypes(RecipeTypes recipeTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeTypes.Add(recipeTypes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipeTypes.RecipeTypeId }, recipeTypes);
        }

        // DELETE: api/RecipeTypes/5
        [ResponseType(typeof(RecipeTypes))]
        public IHttpActionResult DeleteRecipeTypes(int id)
        {
            RecipeTypes recipeTypes = db.RecipeTypes.Find(id);
            if (recipeTypes == null)
            {
                return NotFound();
            }

            db.RecipeTypes.Remove(recipeTypes);
            db.SaveChanges();

            return Ok(recipeTypes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeTypesExists(int id)
        {
            return db.RecipeTypes.Count(e => e.RecipeTypeId == id) > 0;
        }
    }
}