using Microsoft.AspNetCore.Mvc;

namespace Event_Hub.Controllers {
    public class HistoryController : Controller {
        public IActionResult Index () {
            return View ();
        }
    }
}