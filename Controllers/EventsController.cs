using Event_Hub.Models;
using Microsoft.AspNetCore.Mvc;
using Event_Hub.Data;
using System.Linq;

namespace Event_Hub.Controllers {
    public class EventsController : Controller {

        public readonly ApplicationDbContext eventdb;
        public EventsController(ApplicationDbContext database)
        {
            this.eventdb = database;
        }
        public IActionResult Index () {
            var events = eventdb.Events.ToList();
            return View (events);
        }
        public IActionResult Create () {
            return View ();
        }
        public IActionResult Edit (int id) {
            Event events = eventdb.Events.First(register => register.Id == id);
            return View ("Create", events);
        }
        [HttpPost]
        public IActionResult Save (Event events){
            if (events.Id == 0)
            {
                eventdb.Events.Add(events);
            }else{
                Event eventDatabase = eventdb.Events.First(register => register.Id == events.Id);
                eventDatabase.Title = events.Title;
                eventDatabase.Price = events.Price;
                eventDatabase.ReleaseDate = events.ReleaseDate;
                eventDatabase.EventPlace = events.EventPlace;
                eventDatabase.Units = events.Units;
            }
            eventdb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}