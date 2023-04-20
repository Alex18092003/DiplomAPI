using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class KitchensModel
    {
        public KitchensModel(Kitchens kitchens)
        {
            KitchenId = kitchens.KitchenId;
            Title = kitchens.Title;
        }
        public int KitchenId { get; set; }
        public string Title { get; set; }
    }
}