using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TrackerApi.Models;

namespace TrackerApi.Services
{
    public class passLoc : Hub
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void getlocation(double log, double lat,int child_id)
        {
            int? parent_key = db.Childs.Single(ch => ch.Id == child_id).Parent_Id;
            //double loc_log = db.Schaduals.Single(sch => sch.Child_Key == child_id).Location.Log;
            //double loc_lat = db.Schaduals.Single(sch => sch.Child_Key == child_id).Location.Lat;
            //
            //Location loc = new Location() { Lat = loc_lat, Log = loc_log };
            //db.Locations.Add(loc);
            //db.SaveChanges();
            //Clients.All.newloc(lat, log, child_id);
            //
            Clients.User(parent_key.ToString()).newloc(lat,log,child_id);
        }
    }
}