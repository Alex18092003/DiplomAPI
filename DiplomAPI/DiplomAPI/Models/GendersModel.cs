using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class GendersModel
    {
        public GendersModel(Genders genders)
        {
            GenderId = genders.GenderId;
            Title = genders.Title;
        }
        public int GenderId { get; set; }
        public string Title { get; set; }
    }
}