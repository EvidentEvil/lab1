using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend1.Models;

namespace Backend1.Controllers
{
    public class CalcServiceController : Controller
    {
        private readonly ILogger<CalcServiceController> lgr;

        public CalcServiceController(ILogger<CalcServiceController> logger)
        {
            lgr = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassUsingViewData()
        {
            ViewData["calcTitle"] = "PassUsingViewData";

            var rnd = new Random();
            int firstRnd = rnd.Next(0, 10);
            int secondRnd = rnd.Next(0, 10);
            int add = firstRnd + secondRnd;
            int sub = firstRnd - secondRnd;
            int mult = firstRnd * secondRnd;

            try {
                int div = firstRnd / secondRnd;
                ViewData["div"] = div;
            }
            catch (DivideByZeroException) {
                ViewData["div"] = "error";
            }

            ViewData["firstRnd"] = firstRnd;
            ViewData["secondRnd"] = secondRnd;
            ViewData["add"] = add;
            ViewData["sub"] = sub;
            ViewData["mult"] = mult;

            return View("ViewDataCalc");
        }

        public IActionResult PassUsingViewBag()
        {
            ViewBag.calcTitle = "PassUsingViewBag";

            var rnd = new Random();
            int firstRnd = rnd.Next(0, 10);
            int secondRnd = rnd.Next(0, 10);
            int add = firstRnd + secondRnd;
            int sub = firstRnd - secondRnd;
            int mult = firstRnd * secondRnd;

            try {
                int div = firstRnd / secondRnd;
                ViewBag.div = div;
            }
            catch (DivideByZeroException) {
                ViewBag.div = "error";
            }

            ViewBag.firstRnd = firstRnd;
            ViewBag.secondRnd = secondRnd;
            ViewBag.add = add;
            ViewBag.sub = sub;
            ViewBag.mult = mult;

            return View("ViewBagCalc");
        }

        public IActionResult PassUsingModel()
        {
            CalcModel calcModel = new CalcModel();

            return View(calcModel);
        }

        public IActionResult AccessServiceDirectly()
        {
            return View("Injection");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
