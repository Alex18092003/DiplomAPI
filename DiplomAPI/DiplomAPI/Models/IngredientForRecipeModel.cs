using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class IngredientForRecipeModel
    {
        public IngredientForRecipeModel(IngredientForRecipe ingredientForRecipe)
        {
            IngredientForRecipeId = ingredientForRecipe.IngredientForRecipeId;
            IngredientId = ingredientForRecipe.IngredientId;
            RecipeId = ingredientForRecipe.RecipeId;
            UnitsOfMeasurementId = Convert.ToInt32( ingredientForRecipe.UnitsOfMeasurementId);
        }
        public int IngredientForRecipeId { get; set; }
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public int UnitsOfMeasurementId { get; set; }
    }
}