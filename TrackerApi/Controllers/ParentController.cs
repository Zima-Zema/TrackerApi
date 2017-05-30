using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackerApi.Models;

namespace TrackerApi.Controllers
{
    public class ParentController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        
        //select
        public List<Parent> GetAll()
        {
            return _context.Parents.ToList();  

        }

        //Add
        public IHttpActionResult Post(Parent p)
        {

            if (p != null)
            {

                _context.Parents.Add(p);
                _context.SaveChanges();
                return Created("created",p);
            }

            return BadRequest();

        }

        //Edit
        public IHttpActionResult put(Parent p) {
            if (p==null) {
                return BadRequest();
            }

            if (_context.Parents.Find(p.Id)!=null)
            {
                _context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

            return BadRequest();
        }

        //delete
        //public IHttpActionResult Delete(int id)
        //{
        //    Parent p = _context.Parents.Find(id);
        //    if (p!=null)
        //    {
        //        _context.Parents.Remove(p);
        //        _context.SaveChanges();
        //        return Ok(p);
        //    }

        //    return BadRequest();
        //}

    }
}
