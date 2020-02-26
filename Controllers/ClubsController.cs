using System.Linq;
using Event_Hub.Data;
using Event_Hub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event_Hub.Controllers {
    public class ClubsController : Controller {

        private readonly ApplicationDbContext eventdb;
        public ClubsController (ApplicationDbContext database) {
            this.eventdb = database;
        }
        public IActionResult Index () {
            var clubs = eventdb.Clubs.ToList ();
            return View (clubs);
        }

        [Authorize (Policy = "Admin")] public IActionResult Register () {
            return View ();
        }

        [Authorize (Policy = "Admin")] public IActionResult Edit (int id) {
            Club club = eventdb.Clubs.First (register => register.Id == id);
            return View ("Register", club);
        }

        [Authorize (Policy = "Admin")] public IActionResult Delete (int id) {
            Club club = eventdb.Clubs.First (register => register.Id == id);
            eventdb.Clubs.Remove (club);
            eventdb.SaveChanges ();
            return RedirectToAction ("Index");
        }

        [HttpPost]
        public IActionResult Save (Club club) {
            ModelState.Remove("Id");
            if (ModelState.IsValid) {
                if (club.Id == 0) {
                        eventdb.Clubs.Add (club);
                    } else {
                        Club clubDatabase = eventdb.Clubs.First (register => register.Id == club.Id);
                        clubDatabase.Name = club.Name;
                        clubDatabase.Street = club.Street;
                        clubDatabase.Number = club.Number;
                        clubDatabase.ZipCode = club.ZipCode;
                        clubDatabase.City = club.City;
                        clubDatabase.MaximumCapacity = club.MaximumCapacity;
                    }
                    eventdb.SaveChanges ();
                    return RedirectToAction ("Index");
                }else{
                    return View("Register", club);
                }

        }

    }
}