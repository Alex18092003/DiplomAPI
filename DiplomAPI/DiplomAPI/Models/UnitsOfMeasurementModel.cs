using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomAPI.Models
{
    public class UnitsOfMeasurementModel
    {
        public UnitsOfMeasurementModel(UnitsOfMeasurement unitsOfMeasurement)
        {
            UnitsOfMeasurementId = unitsOfMeasurement.UnitsOfMeasurementId;
            Title = unitsOfMeasurement.Title;
        }
        public int UnitsOfMeasurementId { get; set; }
        public string Title { get; set; }
    }
}