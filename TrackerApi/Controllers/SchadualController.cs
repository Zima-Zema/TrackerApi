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
    public class SchadualController : ApiController
    {
        private ApplicationDbContext _context;
        public SchadualController()
        {
            _context = new ApplicationDbContext();
        }
        //GET
        [HttpGet]
        public IHttpActionResult GetSpeed()
        {
            return Ok(_context.Schaduals.Where(s => s.viewFlag == true).Select(s => s));
        }
        //Get By ID
        [HttpGet]
        public IHttpActionResult GetSpacificSpeed(int id)
        {
            var schadule = _context.Schaduals.SingleOrDefault(sch => sch.Child_Key == id);
            if (schadule == null)
            { return NotFound(); }
            return Ok(schadule);
        }
        //post
        [HttpPost]
        public IHttpActionResult CreateSchedule([FromBody] LocationSchadual schloc )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (schloc == null)
            {
                return NotFound();
            }
            schloc.viewFlag = true;
            _context.Schaduals.Add(schloc);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + schloc.Child_Key +"/" + schloc.Location_Key), schloc);
        }

        [HttpPut]
        public IHttpActionResult updateSchadule([FromUri]int childid, [FromUri]int locid, [FromBody]LocationSchadual schloc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var dbschadule = _context.Schaduals.SingleOrDefault(s => s.Child_Key == childid && s.Location_Key==locid);
            if (dbschadule == null)
            {
                return NotFound();
            }
            dbschadule.Child = schloc.Child;
            dbschadule.Location = schloc.Location;
            dbschadule.From = dbschadule.From;
            dbschadule.To = schloc.To;
            dbschadule.isSat = schloc.isSat;
            dbschadule.isSun = schloc.isSun;
            dbschadule.isTue = schloc.isTue;
            dbschadule.isMon = schloc.isMon;
            dbschadule.isThe = schloc.isThe;
            dbschadule.isWed = schloc.isWed;
            dbschadule.isFri = schloc.isFri;

            _context.SaveChanges();
            return Ok();
        }

        //delete
        [HttpDelete]
        public IHttpActionResult DeleteSchadule([FromUri]int childid, [FromUri]int locid)
        {
            var schadule = _context.Schaduals.SingleOrDefault(s => s.Child_Key==childid && s.Location_Key==locid);
            if (schadule == null)
            {
                return NotFound();
            }
            schadule.viewFlag = false;
            _context.SaveChanges();
            return Ok();
        }
    }
}
