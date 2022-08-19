using Microsoft.AspNetCore.Mvc;
using Taske.Models;
using Taske.Repos;
using Taske.ViewModel;

namespace Taske.Controllers
{
    public class TruckController : Controller
    {

        ITruckRepos truckRepos;
        public TruckController(ITruckRepos truckRepos)
        {
            this.truckRepos = truckRepos;
        }
        public IActionResult Trucks()
        {

            return View(truckRepos.GetAll());

        }


        public IActionResult TrucksData()
        {

            return Json(truckRepos.GetAll());

        }


        public IActionResult TruckById(int id)
        {
            return View(truckRepos.FindById(id));
        }
        public IActionResult EditTruck(TruckPositionViewModel truckPosition)
        {
            if (truckPosition != null)
            {
                int result = truckRepos.Edit(truckPosition);
                if (result >= 0)
                {
                    return View("Trucks");

                }
                else
                {
                    return View("Error");
                }
            }

            else
            {
                return View("Error");
            }





        }
    }
}


