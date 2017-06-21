using System;
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

    public class HistoriesController : ApiController
    {
        private ApplicationDbContext _context;
        public HistoriesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Histories
        public IHttpActionResult GetHistories()
        {

            return Ok(_context.Historis.Where(h => h.viewFlag == true).Select(h => h).Include(his => his.Child).OrderByDescending(h=>h.locationId).Take(4).ToList());
        }
        //GET /api/Histories/1
        public IHttpActionResult GetHistory(int id)
        {
            var history = _context.Historis.Where(h => h.Child_Id == id).OrderByDescending(h => h.locationId).Take(4).ToList();
            if (history == null)
            {
                return NotFound();
            }
            return Ok(history);
        }
        [HttpPost]
        public IHttpActionResult CreateHistory([FromBody] LocationHistory history)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (history == null)
            {
                return NotFound();
            }
            history.viewFlag = true;

            _context.Historis.Add(history);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + history.locationId), history);
        }
        //[HttpPut]
        //public IHttpActionResult UpdateHistory([FromUri] int id,[FromBody] LocationHistory history)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var dbHistory = _context.Historis.SingleOrDefault(h => h.Id == id);
        //    if (dbHistory==null)
        //    {
        //        return NotFound();
        //    }
        //    dbHistory.Name = history.Name;
        //    dbHistory.Lat = history.Lat;
        //    dbHistory.Log = history.Log;
        //    dbHistory.From = history.From;
        //    dbHistory.To = history.To;
        //    dbHistory.Date = history.Date;
        //    _context.SaveChanges();
        //    return Ok();
        //}
        [HttpDelete]
        public IHttpActionResult DeleteHistory([FromUri] int id)
        {
            LocationHistory history = _context.Historis.SingleOrDefault(h => h.locationId == id);
            if (history == null)
            {
                return NotFound();
            }
            history.viewFlag = false;
            _context.SaveChanges();
            return Ok();
        }

    }
}
