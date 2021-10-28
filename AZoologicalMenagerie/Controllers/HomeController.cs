using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AZoologicalMenagerie.Models;

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

        public IActionResult Bears()
        {
            ViewData["Message"] = "Welcome to the home of the bears";

            return View();
        }

        public IActionResult Wolves()
        {
            ViewData["Message"] = "Welcome to the home of the wolves";

            return View();
        }

        public IActionResult Foxes()
        {
            ViewData["Message"] = "Welcome to the home of the foxes";

            return View();
        }

        public IActionResult Turtles()
        {
            ViewData["Message"] = "Welcome to the home of the turtles";

            return View();
        }

        public IActionResult Fish()
        {
            ViewData["Message"] = "With hundreds of fish, here are some species to look out for in our pond.";

            return View();
        }

        public IActionResult Merchandise()
        {
            ViewData["Message"] = "Feel free to look for what you need.";

            return View();
        }

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
