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
            Connection_ids = new List<Connection_id>();
        }
        [Required]
        public string Lname { get; set; }
        public bool viewFlag { get; set; }
        public virtual List<Child> Childs { get; set; }
        //  public  Connection_id Connection_id { get; set; }
        public virtual List<Connection_id> Connection_ids { get; set; }

    }
}