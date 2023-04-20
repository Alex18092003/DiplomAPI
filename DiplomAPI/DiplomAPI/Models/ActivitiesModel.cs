using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class ActivitiesModel
    {
        public ActivitiesModel(Activities activities)
        {
            ActivityId = activities.ActivityId;
            Title = activities.Title;
            Coefficient = activities.Coefficient;
        }
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public double Coefficient { get; set; }
    }
}