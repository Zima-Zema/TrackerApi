using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TrackerApi.Models;
using System.Data.Entity;
using System.Web.Http.Cors;

namespace TrackerApi.Controllers
{
    [EnableCors(origins: "http://http://localhost:28529/", headers: "*", methods: "*")]
    public class LocationsController : ApiController
    {
        private ApplicationDbContext _context;
        public LocationsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/locations
        public IHttpActionResult GetLocations()
        {
            return Ok(_context.Locations.Where(lo=>lo.viewFlag==true).Select(ll=>ll).Include(l => l.Schaduals).ToList());
        }
        //GET /api/locations/1
        public IHttpActionResult GetLocation(int id)
        {
            var location = _context.Locations.SingleOrDefault(l => l.Id == id);
            if (location==null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateLocation([FromBody]Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (location==null)
            {
                return NotFound();
            }
            location.viewFlag = true;
            _context.Locations.Add(location);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + location.Id), location);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateLocation([FromUri] int id ,[FromBody] Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var dbLocation = _context.Locations.SingleOrDefault(l => l.Id == id);
            if (dbLocation==null)
            {
                return NotFound();
            }
            dbLocation.Name = location.Name;
            dbLocation.Lat = location.Lat;
            dbLocation.Log = location.Log;
            _context.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteLocation([FromUri]int id)
        {
            var dbLocation = _context.Locations.SingleOrDefault(l => l.Id == id);
            if (dbLocation==null)
            {
                return NotFound();
            }
            dbLocation.viewFlag = false;
            _context.SaveChanges();
            return Ok();
        }

       
    }
}
