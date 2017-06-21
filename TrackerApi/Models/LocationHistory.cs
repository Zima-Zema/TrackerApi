using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class LocationHistory
    {
        [Key]
        public int locationId { get; set; }
        public string serviceProvider { get; set; }
        public bool debug { get; set; }

        public double? time { get; set; }
        public double? accuracy { get; set; }
        public double? speed { get; set; }
        public double? longitude { get; set; }
        public double? latitude { get; set; }
        public double? altitude { get; set; }
        public double? altitudeAccuracy { get; set; }
        public double? bearing { get; set; }
        public double? timestamp { get; set; }
        public Coordinates coords { get; set; }
        public bool viewFlag { get; set; }

        [ForeignKey("Child")]
        public int Child_Id { get; set; }
        public Child Child { get; set; }
    }
}