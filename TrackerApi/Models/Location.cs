using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Location Name")][StringLength(250)]
        [DataType(DataType.Text, ErrorMessage = "Please enter valid Name")]
        public string Name { get; set; }
        public string FullAddress { get; set; }
        [Required]
        public double Lng { get; set; }
        [Required]
        public double Lat { get; set; }
        [ForeignKey("Parent")]
        public int Parent_key { get; set; }
        public Parent Parent { get; set; }
        public bool viewFlag { get; set; }

        public virtual List<LocationSchadual> Schaduals { get; set; }

    }
}