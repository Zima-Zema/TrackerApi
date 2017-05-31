using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class Child:AppUser
    {
        [Required]
        public string Lname { get; set; }

        [ForeignKey("parent")]
        public int Parent_Id { get; set; }
        public Parent parent { get; set; }
        public bool viewFlag { get; set; }

        public virtual List<LocationHistory> LocHistorys { get; set; }
        public virtual List<LocationSchadual> Schaduals { get; set; }



    }
}