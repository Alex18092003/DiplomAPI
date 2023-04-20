using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class RecipeTypesModel
    {
        public RecipeTypesModel(RecipeTypes recipeTypes)
        {
            RecipeTypeId = recipeTypes.RecipeTypeId;
            Title = recipeTypes.Title;
        }
        public int RecipeTypeId { get; set; }
        public string Title { get; set; }
    }
}