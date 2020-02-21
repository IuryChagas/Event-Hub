using Event_Hub.Models;
using Microsoft.AspNetCore.Mvc;
using Event_Hub.Data;
using System.Linq;

namespace Event_Hub.Controllers {
    public class ClubsController : Controller {

        private readonly ApplicationDbContext eventdb;
        public ClubsController(ApplicationDbContext database)
        {
            this.eventdb = database;
        }
        public IActionResult Index () {
            var clubs = eventdb.Clubs.ToList();
            return View (clubs);
        }
        public IActionResult Register () {
            return View ();
        }
        public IActionResult Edit (int id) {
            Club club = eventdb.Clubs.First(register => register.Id == id);
            return View ("Register", club);
        }
        [HttpPost]
        public IActionResult Save (Club club){
            if (club.Id == 0)
            {
                eventdb.Clubs.Add(club);
            }else{
                Club clubDatabase = eventdb.Clubs.First(register => register.Id == club.Id);
                clubDatabase.Name = club.Name;
                clubDatabase.Street = club.Street;
                clubDatabase.Number = club.Number;
                clubDatabase.Cep = club.Cep;
                clubDatabase.City = club.City;
                clubDatabase.MaximumCapacity = club.MaximumCapacity;
            }
            eventdb.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}