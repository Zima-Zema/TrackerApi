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
        public int Id { get; set; }
        [Required]
        [Display(Name = "History Name")]
        [StringLength(250)]
        [DataType(DataType.Text, ErrorMessage = "Please enter valid Name")]
        public string Name { get; set; }
        
        public DateTime Date { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        [Required]
        public double Log { get; set; }
        [Required]
        public double Lat { get; set; }

        [ForeignKey("Child")]
        public int Child_Id { get; set; }
        public Child Child { get; set; }
    }
}