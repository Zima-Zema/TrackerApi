using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class SpeedNotify: Notification
    {
        public double Lng { get; set; }
        public double Lat { get; set; }

        public float Value { get; set; }

        public DateTime Date { get; set; }

    }
}