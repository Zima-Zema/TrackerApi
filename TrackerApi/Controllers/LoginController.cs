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
        [HttpPost]
        [Route("~/api/Login/parent")]
        public IHttpActionResult LoginParent([FromBody]LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest();
            }
            
            var parent = _context.Parents.SingleOrDefault(a => a.Email.ToLower() == model.Email.ToLower() && a.Password == model.Password);
            if (parent==null)
            {
                return NotFound();
            }
            return Ok(parent);
        }

        [HttpPost]
        [Route("~/api/Login/child")]
        public IHttpActionResult LoginChild([FromBody]LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest();
            }

            var child = _context.Childs.SingleOrDefault(a => a.Email.ToLower() == model.Email.ToLower() && a.Password == model.Password);
            if (child == null)
            {
                return NotFound();
            }
            return Ok(child);
        }
    }
}
