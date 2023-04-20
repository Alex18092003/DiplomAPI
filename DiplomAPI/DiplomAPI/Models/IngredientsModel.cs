using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class IngredientsModel
    {
        public IngredientsModel(Ingredients ingredients)
        {
            IngredientId = ingredients.IngredientId;
            Title = ingredients.Title;
        }
        public int IngredientId { get; set; }
        public string Title { get; set; }
    }
}