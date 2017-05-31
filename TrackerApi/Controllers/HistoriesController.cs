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
    public class HistoriesController : ApiController
    {
        private ApplicationDbContext _context;
        public HistoriesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetHistories()
        {
            return Ok();
        }
    }
}
