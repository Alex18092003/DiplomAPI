using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class RecipesModel
    {
        public RecipesModel(Recipes recipes)
        {
            RecipeId = recipes.RecipeId;
            Title = recipes.Title;
            MinutesOfCooking = recipes.MinutesOfCooking;
            Description = recipes.Description;
            Comment = recipes.Comment;
            Photo = recipes.Photo;
            MealId = Convert.ToInt32( recipes.MealId);
            RecipeType = Convert.ToInt32(recipes.RecipeType);
            DietId = Convert.ToInt32(recipes.DietId);
            SpecificsId = Convert.ToInt32(recipes.SpecificsId);
            DifficultyId = Convert.ToInt32(recipes.DifficultyId);
            CookingId = Convert.ToInt32(recipes.CookingId);
            KitchenId = Convert.ToInt32(recipes.KitchenId);
            Calories = Convert.ToInt32(recipes.Calories);
        }
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public int MinutesOfCooking { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Photo { get; set; }
        public int MealId { get; set; }
        public int RecipeType { get; set; }
        public int DietId { get; set; }
        public int SpecificsId { get; set; }
        public int DifficultyId { get; set; }
        public int CookingId { get; set; }
        public int KitchenId { get; set; }
        public int Calories { get; set; }

    }
}