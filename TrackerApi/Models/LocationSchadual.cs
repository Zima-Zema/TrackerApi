using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class LocationSchadual
    {
        [Key]
        [Column(Order =1)]
        [ForeignKey("Location")]
        public int? Location_Key { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Child")]
        public int? Child_Key { get; set; }


        public virtual Location Location { get; set; }
        public virtual Child Child { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public bool isSat { get; set; }
        public bool isSun { get; set; }
        public bool isMon { get; set; }
        public bool isTue { get; set; }
        public bool isWed { get; set; }
        public bool isThe { get; set; }
        public bool isFri { get; set; }
        public bool viewFlag { get; set; }

        public bool isRepeated { get; set; }
    }
}