using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class UsersModel
    {
        public UsersModel(Users users)
        {
            UserId = users.UserId;
            GenderId =  Convert.ToInt32(users.GenderId);
            Login = users.Login;
            Weight = Convert.ToDouble( users.Weight);
            Height = Convert.ToDouble( users.Height);
            ActivityId = Convert.ToInt32( users.ActivityId);
            GoalId = Convert.ToInt32(users.GoalId);
            Calories = Convert.ToInt32(users.Calories);
            Squirrels = Convert.ToDouble( users.Squirrels);
            DateOfBirth = Convert.ToInt32( users.DateOfBirth);
            Password = users.Password;
            Fats = Convert.ToDouble(users.Fats);
            Carbohydrates = Convert.ToDouble(users.Carbohydrates);
        }
        public int UserId { get; set; }
        public int GenderId { get; set; }
        public string Login { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int ActivityId { get; set; }
        public int GoalId { get; set; }
        public int Calories { get; set; }
        public double Squirrels { get; set; }
        public int DateOfBirth { get; set; }
        public string Password { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }

    }
}