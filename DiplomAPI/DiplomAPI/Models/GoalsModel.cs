using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class GoalsModel
    {
        public GoalsModel(Goals goals)
        {
            GoalId = goals.GoalId;
            Title = goals.Title;
        }
        public int GoalId { get; set; }
        public string Title { get; set; }
    }
}