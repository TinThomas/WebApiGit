using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiGit.Models;


namespace WebApiGit.Controllers
{
    [Route("[Controller]")]
    public class WeatherForecastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(WeatherForecastModel model)
        {
            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            return View();
        }

    }
}
