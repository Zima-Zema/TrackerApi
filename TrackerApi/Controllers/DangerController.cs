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
    public class DangerController : ApiController
    {
        private ApplicationDbContext _context;
        public DangerController()
        {
            _context = new ApplicationDbContext();
        }
        //GET
        [HttpGet]
        public IHttpActionResult GetDanger()
        {
            return Ok(_context.DangerNotifys.Where(d=>d.viewFlag==true).Select(d=>d));
        }
        //GET by ID
        [HttpGet]
        public IHttpActionResult GetSpacificDanger(int id)
        {
            var danger = _context.DangerNotifys.SingleOrDefault(d=>d.Id==id);
            if(danger==null)
            { return NotFound(); }
            return Ok(danger);
        }
        //POST
        [HttpPost]
        public IHttpActionResult CreateDanger([FromBody] DangerNotify danger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (danger == null)
            {
                return NotFound();
            }
            danger.viewFlag = true;
            _context.DangerNotifys.Add(danger);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + danger.Id), danger);
        }
        //PUT
        [HttpPut]
        public IHttpActionResult updateDanger([FromUri]int id, [FromBody]DangerNotify danger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var dbdanger = _context.DangerNotifys.SingleOrDefault(d => d.Id == id);
            if (dbdanger == null)
            {
                return NotFound();
            }
            dbdanger.Date = danger.Date;
            dbdanger.Desc = danger.Desc;
            dbdanger.Lat = danger.Lat;
            dbdanger.Lng = danger.Lng;
            _context.SaveChanges();
            return Ok();
        }
        //delete
        [HttpDelete]
        public IHttpActionResult DeleteDanger([FromUri] int id)
        {
            var danger = _context.DangerNotifys.SingleOrDefault(d => d.Id == id);
            if (danger == null)
            {
                return NotFound();
            }
            danger.viewFlag = false;
            _context.SaveChanges();
            return Ok();
        }
    }
}
