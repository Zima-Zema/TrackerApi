using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerApi.Models
{
    public enum Role
    {
        Admin=1,
        Parent,
        Child
    }
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text, ErrorMessage = "Please enter valid Name")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Valid Email")]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Enter Valid Phone")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Enter Valid Mobile Phone")]
        public string Telephone { get; set; }
        public FullAddress Address { get; set; }
        public Role UserRole { get; set; }

        
    }
}