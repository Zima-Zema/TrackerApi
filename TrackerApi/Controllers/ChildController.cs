using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackerApi.Models;

namespace TrackerApi.Controllers
{
    public class ChildController : ApiController
    {
        
            ApplicationDbContext _context = new ApplicationDbContext();

            //select
            public List<Child> GetAll()
            {
                return _context.Childs.ToList();

            }

            //Add
            public IHttpActionResult Post(Child c)
            {

                if (c != null)
                {

                    _context.Childs.Add(c);
                    _context.SaveChanges();
                    return Created("created", c);
                }

                return BadRequest();

            }

            //Edit
            public IHttpActionResult put(Child c)
            {
                if (c == null)
                {
                    return BadRequest();
                }

                if (_context.Childs.Find(c.Id) != null)
                {
                    _context.Entry(c).State = System.Data.Entity.EntityState.Modified;
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

