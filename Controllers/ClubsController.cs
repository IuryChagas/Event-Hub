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
        public IActionResult Save (EventPlace eventPlace){
            return Content("Saved!");
        }

    }
}