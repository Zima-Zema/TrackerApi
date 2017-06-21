using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class Coordinates
    {
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public double? altitude { get; set; }
        public double? speed { get; set; }
        public double? accuracy { get; set; }
        public double? altitudeAccuracy { get; set; }
        public double? heading { get; set; }

    }
}