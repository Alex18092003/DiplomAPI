using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class MealsModel
    {
        public MealsModel(Meals meals)
        {
            MealId = meals.MealId;
            Title = meals.Title;
        }
        public int MealId { get; set; }
        public string Title { get; set; }
    }
}