using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AZoologicalMenagerie.Models;
using Microsoft.AspNetCore.Authorization;

namespace AZoologicalMenagerie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Welcome to the best Zoo in town.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Got a question, send it to the email below.";

            return View();
        }

        //Only allow registgered users to access this page
        [Authorize]
        public IActionResult Bears()
        {
            ViewData["Message"] = "Welcome to the home of the bears";

            return View();
        }

        //Only allow registgered users to access this page
        [Authorize]
        public IActionResult Wolves()
        {
            ViewData["Message"] = "Welcome to the home of the wolves";

            return View();
        }

        //Only allow registgered users to access this page
        [Authorize]
        public IActionResult Foxes()
        {
            ViewData["Message"] = "Welcome to the home of the foxes";

            return View();
        }

        //Only allow registgered users to access this page
        [Authorize]
        public IActionResult Turtles()
        {
            ViewData["Message"] = "Welcome to the home of the turtles";

            return View();
        }

        //Only allow registgered users to access this page
        [Authorize]
        public IActionResult Fish()
        {
            ViewData["Message"] = "With hundreds of fish, here are some species to look out for in our pond.";

            return View();
        }

        //Only allow registgered users to access this page
        [Authorize]
        public IActionResult Merchandise()
        {
            ViewData["Message"] = "Feel free to look for what you need.";

            return View();
        }

        //Only allow registgered users to access this page
        [Authorize]
        public IActionResult EnclosuresPending()
        {
            ViewData["Message"] = "Featuring, the pending enclosures.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
