using Event_Hub.Models;
using Microsoft.AspNetCore.Mvc;
using Event_Hub.Data;

namespace Event_Hub.Controllers {
    public class ClubsController : Controller {

        private readonly ApplicationDbContext eventdb;
        public ClubsController(ApplicationDbContext database)
        {
            this.eventdb = database;
        }
        public IActionResult Index () {
            return View ();
        }
        public IActionResult Register () {
            return View ();
        }
        [HttpPost]
        public IActionResult Save (Club club){
            eventdb.Clubs.Add(club);
            eventdb.SaveChanges();
            return Content("Club registered successfully!");
        }

    }
}