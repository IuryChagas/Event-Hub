using Event_Hub.Models;
using Microsoft.AspNetCore.Mvc;
using Event_Hub.Data;

namespace Event_Hub.Controllers {
    public class EventsController : Controller {

        public readonly ApplicationDbContext eventdb;
        public EventsController(ApplicationDbContext database)
        {
            this.eventdb = database;
        }
        public IActionResult Index () {
            return View ();
        }
        public IActionResult Create () {
            return View ();
        }
        
        [HttpPost]
        public IActionResult Save (Event events){
            eventdb.Events.Add(events);
            eventdb.SaveChanges();
            return Content("Event successfully published!");
        }
    }
}