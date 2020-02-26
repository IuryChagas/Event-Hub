using Event_Hub.Models;
using Microsoft.AspNetCore.Mvc;
using Event_Hub.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Event_Hub.Controllers {
    public class EventsController : Controller {

        public readonly ApplicationDbContext eventdb;
        public EventsController(ApplicationDbContext database)
        {
            this.eventdb = database;
        }
        public IActionResult Index () {
            var events = eventdb.Events.Include(x => x.Club).ToList();
            return View (events);
        }
        [Authorize(Policy = "Admin")] public IActionResult Create () {
            ViewBag.validClub = eventdb.Clubs.Count();
            ViewBag.Clubs = eventdb.Clubs.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            return View ();
        }
        [Authorize(Policy = "Admin")] public IActionResult Edit (int id) {
            
            ViewBag.validClub = eventdb.Clubs.Count();
            ViewBag.Clubs = eventdb.Clubs.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            Event events = eventdb.Events.First(register => register.Id == id);
            return View ("Create", events);
        }
        [Authorize(Policy = "Admin")] public IActionResult Delete (int id) {
            Event events = eventdb.Events.First(register => register.Id == id);
            eventdb.Events.Remove(events);
            eventdb.SaveChanges();
            return RedirectToAction ("Index");
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
                eventDatabase.Club = events.Club;
                eventDatabase.Units = events.Units;
            }
            eventdb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}