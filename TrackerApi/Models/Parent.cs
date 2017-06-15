﻿using System;
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
            Locations = new List<Location>();
        }
        [Required]
        public string Lname { get; set; }
        public bool viewFlag { get; set; }
        public virtual List<Child> Childs { get; set; }
        public virtual List<Location> Locations { get; set; }
    }
}