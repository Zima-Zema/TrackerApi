using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using TrackerApi.Models;

namespace TrackerApi.service
{
    public static class User_con
    {
        public static HashSet<Connection_id> ConnectedIds = new HashSet<Connection_id>();
        //public static HashSet<string> ConnectedIds = new HashSet<string>();
    }
    public class passLoc : Hub
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //
        public void getlocation(double log, double lat, int child_id, int parent_id)
        {

            int? parent_key = db.Childs.Single(ch => ch.Id == child_id).Parent_Id;
            //
            if (parent_id == parent_key)
            {
                 List<string> conn = db.Connection_ids.Where(con => con.Parent_Id == parent_id).Select(con => con.Con_key).ToList();
                // string zz = Context.ConnectionId;
                 Clients.Clients(conn).newloc(lat, log, child_id); 
            }
            else
            {
                Clients.All.newloc(lat, log, child_id);
            }
        }     
        //
        public override Task OnConnected()
        {
            //
            Clients.All.recievemsg($"{Context.ConnectionId}: connected");
            //
            var ChId = Context.QueryString["ChId"];
            var PrntId = Context.QueryString["PrntId"];
            //          
            Parent Parent = db.Parents.Single(ch => ch.Id.ToString() == ChId);
            //
            Connection_id conn_id = new Connection_id() { Con_key = Context.ConnectionId, Parent_Id = int.Parse(PrntId), parent = Parent };
            User_con.ConnectedIds.Add(conn_id);
            db.Connection_ids.Add(conn_id);
            db.SaveChanges();
            //
            return base.OnConnected();
            
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.recievemsg_dis($"{Context.ConnectionId}: disconnected");
            //
            var ChId = Context.QueryString["ChId"];
            var PrntId = Context.QueryString["PrntId"];
            //          
            Parent Parent = db.Parents.Single(ch => ch.Id.ToString() == ChId);
            //
            Connection_id conn_id = new Connection_id() { Con_key = Context.ConnectionId, Parent_Id = int.Parse(PrntId), parent = Parent };
            User_con.ConnectedIds.Remove(conn_id);
            db.Connection_ids.Remove(conn_id);
            db.SaveChanges();
            return base.OnDisconnected(stopCalled);
        }
    }
}