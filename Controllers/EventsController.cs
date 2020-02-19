using Microsoft.AspNetCore.Mvc;

namespace Event_Hub.Controllers {
    public class EventsController : Controller {
        public IActionResult Index () {
            return View ();
        }
        public IActionResult Register () {
            return View ();
        }
    }
}