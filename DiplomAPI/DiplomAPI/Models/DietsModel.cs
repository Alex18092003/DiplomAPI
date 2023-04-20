using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class DietsModel
    {
        public DietsModel(Diets diets)
        {
            DietId = diets.DietId;
            Title = diets.Title;
        }
        public int DietId { get; set; }
        public string Title { get; set; }
    }
}