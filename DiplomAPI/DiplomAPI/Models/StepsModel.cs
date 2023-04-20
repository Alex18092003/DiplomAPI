using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class StepsModel
    {
        public StepsModel(Steps steps)
        {
            StepId = steps.StepId;
            RecipeId = steps.RecipeId;
            StepNomen = steps.StepNomen;
            Description = steps.Description;
            Photo = steps.Photo;
        }
        public int StepId { get; set; }
        public int RecipeId { get; set; }
        public int StepNomen { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}