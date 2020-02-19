using Event_Hub.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Hub.Controllers {
    public class ClubsController : Controller {
        public IActionResult Index () {
            return View ();
        }
        public IActionResult Register () {
            return View ();
        }
        [HttpPost]
        public IActionResult Save (Club club){
            return Content("Saved!");
        }

    }
}