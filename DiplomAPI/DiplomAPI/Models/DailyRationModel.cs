using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class DailyRationModel
    {
        public DailyRationModel(DailyRation dailyRation)
        {
            DailyRationId = dailyRation.DailyRationId;
            UserId = dailyRation.UserId;
            RecepeId = dailyRation.RecepeId;
            Date = dailyRation.Date;
        }
        public int DailyRationId { get; set; }
        public int UserId { get; set; }
        public int RecepeId { get; set; }
        public DateTime Date { get; set; }
    }
}