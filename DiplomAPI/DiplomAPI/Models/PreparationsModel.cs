using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class PreparationsModel
    {
        public PreparationsModel(Preparations preparations)
        {
            PreparationId = preparations.PreparationId;
            Title = preparations.Title;
        }
        public int PreparationId { get; set; }
        public string Title { get; set; }
    }
}