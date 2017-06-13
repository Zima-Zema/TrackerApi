using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public class Connection_id
    {
       [Key]
        public string Con_key { get; set; }
        [ForeignKey("parent")]
        public int Parent_Id { get; set; }
        [Required]
        public Parent parent { get; set; }
    }
    
}