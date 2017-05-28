using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class Parent: AppUser
    {

        public Parent()
        {
            Childs = new List<Child>();
        }
        [Required]
        public string Lname { get; set; }

        public virtual List<Child> Childs { get; set; }
        


    }
}