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
    public class SpeedController : ApiController
    {
        private ApplicationDbContext _context;
        public SpeedController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/Speed
        [HttpGet]
        public IHttpActionResult GetSpeed()
        {
            return Ok(_context.SpeedNotifys.Where(s => s.viewFlag == true).Select(s => s));
        }
        //Get By ID
        [HttpGet]
        public IHttpActionResult GetSpacificSpeed(int id)
        {
            var speed = _context.SpeedNotifys.SingleOrDefault(s => s.Id == id);
            if(speed==null)
            { return NotFound(); }
            return Ok(speed);
        }
        //post
        [HttpPost]
        public IHttpActionResult CreateSpeed([FromBody] SpeedNotify speed)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(speed==null)
            {
                return NotFound();
            }
            speed.viewFlag = true;
            _context.SpeedNotifys.Add(speed);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + speed.Id), speed);
        }
        //put
        [HttpPut]
        public IHttpActionResult updateSpeed([FromUri]int id,[FromBody]SpeedNotify speed)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var dbspeed = _context.SpeedNotifys.SingleOrDefault(s=>s.Id==id);
            if(dbspeed==null)
            {
                return NotFound();
            }
            dbspeed.Lng = speed.Lng;
            dbspeed.Lat = speed.Lat;
            dbspeed.Value = speed.Value;
            dbspeed.Date = speed.Date;
            _context.SaveChanges();
            return Ok();
        }
        //delete
        [HttpDelete]
        public IHttpActionResult DeleteSpeed([FromUri] int id)
        {
            var speed = _context.SpeedNotifys.SingleOrDefault(s => s.Id == id);
            if(speed ==null)
            {
                return NotFound();
            }
            speed.viewFlag = false;
            _context.SaveChanges();
            return Ok();
        }
    }
}
