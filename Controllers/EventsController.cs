using Event_Hub.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Hub.Controllers {
    public class EventsController : Controller {
        public IActionResult Index () {
            return View ();
        }
        public IActionResult Create () {
            return View ();
        }
        
        [HttpPost]
        public IActionResult Save (Event events){
            return Content("Saved!");
        }
    }
}