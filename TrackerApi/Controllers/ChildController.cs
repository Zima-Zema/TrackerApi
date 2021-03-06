﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TrackerApi.Models;


namespace TrackerApi.Controllers
{
   
    public class ChildController : ApiController
    {

        ApplicationDbContext _context = new ApplicationDbContext();

        // //GET /api/child
        public IHttpActionResult GetAll()
        {
            return Ok(_context.Childs.Where(lo => lo.viewFlag == true).Select(ll => ll).Include(li => li.parent).ToList());
        }


        //GET /api/childs/1
        public IHttpActionResult GetChild(int id)
        {
            var child = _context.Childs.SingleOrDefault(c => c.Id == id);
            if (child == null)
            {
                return NotFound();
            }
            return Ok(child);
        }

        [HttpPost]
        [Route("~/api/Child/GetByEmail")]
        public IHttpActionResult GetByEmail([FromBody]string email)
        {
            var parent = _context.Childs.FirstOrDefault(p => p.Email.ToLower() == email.ToLower());
            return Ok(parent);
        }

        //Create child
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateChild([FromBody]Child c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (c == null)
            {
                return NotFound();
            }
            c.viewFlag = true;
            _context.Childs.Add(c);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + c.Id), c);


        }

        //Edit
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateChild([FromUri] int id, [FromBody] Child c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var child = _context.Childs.SingleOrDefault(l => l.Id == id);
            if (child == null)
            {
                return NotFound();
            }
            child.Fname = c.Fname;
            child.Lname = c.Lname;
            child.Telephone = c.Telephone;
            child.Email = c.Email;
            child.Password = c.Password;
            child.ImageUrl = c.ImageUrl;
            child.Address = c.Address;
            child.UserRole = c.UserRole;
            _context.SaveChanges();
            return Ok(child);
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteChild([FromUri]int id)
        {
            var child = _context.Childs.SingleOrDefault(l => l.Id == id);
            if (child == null)
            {
                return NotFound();
            }
            child.viewFlag = false;
            _context.SaveChanges();
            return Ok();
        }
    }
}

