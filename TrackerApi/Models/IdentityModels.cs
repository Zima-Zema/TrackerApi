using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Valid Email")]
        [EmailAddress]
        [Index(IsUnique = true)]
        public override string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Parent> Parents{ get; set; }
        public virtual DbSet<Child> Childs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationHistory> Historis { get; set; }
        public virtual DbSet<LocationSchadual> Schaduals { get; set; }

        public virtual DbSet<SpeedNotify> SpeedNotifys { get; set; }
        public virtual DbSet<DangerNotify> DangerNotifys { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}