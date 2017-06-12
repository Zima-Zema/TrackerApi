using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using TrackerApi.Models;

namespace TrackerApi.service
{    
    public class passLoc : Hub
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void getlocation(double log, double lat, int child_id, string parent_id)
        {
            int? parent_key = db.Childs.Single(ch => ch.Id == child_id).Parent_Id;
            //double loc_log = db.Schaduals.Single(sch => sch.Child_Key == child_id).Location.Log;
            //double loc_lat = db.Schaduals.Single(sch => sch.Child_Key == child_id).Location.Lat;
            //Location loc = new Location() { Lat = loc_lat, Log = loc_log };
            //db.Locations.Add(loc);
            //db.SaveChanges();        
            //
            if (parent_id == parent_key.ToString())
            {
                Clients.User(parent_id).newloc(lat, log, child_id);
                //
               // Groups.Add(Context.ConnectionId, "family1");
                //Clients.OthersInGroup("family1").newloc(lat, log, child_id);
                //
            }
            else
            {
                Clients.All.newloc(lat, log, child_id);
            }
        }

        public override Task OnConnected()
        {
            Clients.All.recievemsg($"{Context.ConnectionId}: connected");
            return base.OnConnected();
        }
    }

    public class PrincipalUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            if (request.User != null && request.User.Identity != null)
                return request.User.Identity.Name;
            else
                return (string)null;
        }
    }
}