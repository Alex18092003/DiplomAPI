using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class SpecificsModel
    {
        public SpecificsModel(Specifics specifics)
        {
            SpecificityId = specifics.SpecificityId;
            Title = specifics.Title;
        }
        public int SpecificityId { get; set; }
        public string Title { get; set; }
    }
}