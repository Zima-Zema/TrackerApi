using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TrackerApi.Models;

namespace TrackerApi.Controllers
{
   
    public class LoginController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult GetParent(string username,string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest();
            }
            //var id = _context.Parents.Where(a => a.Email == username && a.Password == password).Select(a=>a);
            var parent = _context.Parents.SingleOrDefault(a => a.Email == username && a.Password == password);

            if (parent == null)
            {
                return NotFound();
            }
            return Ok(parent);
        }
    }
}
