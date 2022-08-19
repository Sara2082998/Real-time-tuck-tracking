using Microsoft.AspNetCore.SignalR;
using Taske.Repos;
using Taske.Models;
using Taske.ViewModel;

namespace Taske.Hubs
{
    public class TruckHub : Hub
    {
        Tracking_taskContext db;
        public TruckHub(Tracking_taskContext db)

        {
            this.db = db;
        }
        public void sendTruck(TruckPositionViewModel truckposition)
        {
            //save db


            Truck tr = db.Trucks.SingleOrDefault(t=>t.id==truckposition.id);
            if (tr != null)
            {

                tr.latitude = truckposition.lat;
                tr.longitude = truckposition.longe;
               


                int raw = db.SaveChanges();
                List<Truck> trucks = db.Trucks.ToList();
               
                //send data to all online clients
                Clients.All.SendAsync("changtruckposition", trucks);
            }
        }
    }
}
