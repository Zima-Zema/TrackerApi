using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Child")]
        public int Child_key { get; set; }
        public Child Child { get; set; }

    }
}