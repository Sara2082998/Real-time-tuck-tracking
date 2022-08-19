using Taske.Models;
using Taske.ViewModel;

namespace Taske.Repos
{
    public interface ITruckRepos
    {
        int Edit(TruckPositionViewModel truckPosition);
        Truck FindById(int id);
        List<Truck> GetAll();
    }
}
