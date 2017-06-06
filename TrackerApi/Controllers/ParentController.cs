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
    [EnableCors(origins: "http://http://localhost:28529/", headers: "*", methods: "*")]
    public class ParentController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // //GET /api/parents
        public IHttpActionResult GetAll()
        {
            return Ok(_context.Parents.Where(lo => lo.viewFlag == true).Select(ll => ll).ToList());

        }


        //GET /api/parents/1
        public IHttpActionResult GetParent(int id)
        {
            var parent = _context.Parents.SingleOrDefault(p => p.Id == id);
            if (parent == null)
            {
                return NotFound();
            }
            return Ok(parent);
        }

        //Create Parent
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateParent([FromBody]Parent p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (p == null)
            {
                return NotFound();
            }
            p.viewFlag = true;
            _context.Parents.Add(p);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + p.Id), p);
          

        }

        //Edit
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateParent([FromUri] int id, [FromBody] Parent p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Parent = _context.Parents.SingleOrDefault(l => l.Id == id);
            if (Parent == null)
            {
                return NotFound();
            }
            Parent.Fname = p.Fname;
            Parent.Lname = p.Lname;
            Parent.Telephone = p.Telephone;
            Parent.Email = p.Email;
            Parent.Password = p.Password;
            Parent.ImageUrl = p.ImageUrl;
            Parent.Address = p.Address;
            Parent.UserRole = p.UserRole;
            _context.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteParent([FromUri]int id)
        {
            var parent = _context.Parents.SingleOrDefault(l => l.Id == id);
            if (parent == null)
            {
                return NotFound();
            }
            parent.viewFlag = false;
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetChildren(int Parentid)
        {
            var Children = _context.Childs.Where(c => c.Id == Parentid).ToList();
            if (Children == null)
            {
                return NotFound();
            }
            return Ok(Children);
        }


    }
}
