using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Event_Hub.Models;
using Microsoft.AspNetCore.Authorization;
using Event_Hub.Data;
using Microsoft.EntityFrameworkCore;

namespace Event_Hub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public HomeController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var Events = _dbcontext.Events.Include(x => x.Club).ToList();
            return View(Events);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
