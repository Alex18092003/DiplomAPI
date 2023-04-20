using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class DifficultiesModel
    {
        public DifficultiesModel(Difficulties difficulties)
        {
            DifficultiesId = difficulties.DifficultiesId;
            Title = difficulties.Title;
        }
        public int DifficultiesId { get; set; }
        public string Title { get; set; }
    }
}