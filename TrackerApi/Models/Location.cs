using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int Log { get; set; }
        [Required]
        public int Lat { get; set; }

        public bool viewFlag { get; set; }

        public virtual List<LocationSchadual> Schaduals { get; set; }

    }
}