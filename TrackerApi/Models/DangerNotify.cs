using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class DangerNotify:Notification
    {
        public double Lng { get; set; }
        public double Lat { get; set; }

        public DateTime Date { get; set; }
        public string Desc { get; set; }
        public bool viewFlag { get; set; }

    }
}