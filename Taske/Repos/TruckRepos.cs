using Taske.Models;
using Taske.ViewModel;
namespace Taske.Repos
{
    public class TruckRepos:ITruckRepos
    {
        Tracking_taskContext db;
        public TruckRepos(Tracking_taskContext db)
        {
            this.db = db;
        }

        public List<Truck> GetAll()
        {
            return db.Trucks.ToList();
        }
       
        public List<Truck> searchByName(string name)
        {
            return db.Trucks.Where(p => p.Name.Contains(name)).ToList();
        }
        public Truck FindById(int id)
        {
            return db.Trucks.FirstOrDefault(x => x.id == id);
        }

        public int Edit(TruckPositionViewModel truckPosition)
        {
            Truck tr = FindById(truckPosition.id);
            if (tr != null)
            {
                
                tr.latitude = truckPosition.lat;
                tr.longitude = truckPosition.longe;
                
                
                int raw = db.SaveChanges();
                return raw;
            }
            return 0;
        }

        
}
}
