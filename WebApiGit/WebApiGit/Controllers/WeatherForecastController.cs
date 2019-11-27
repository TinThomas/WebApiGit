using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiGit.Models;


namespace WebApiGit.Controllers
{
    [Route("[Controller]")]
    public class WeatherForecastController : Controller
    {
         public static List<WeatherForecastModel> ForecastList = new List<WeatherForecastModel>();

        [HttpGet("Index")]
        public IActionResult Index()
        {
            Debug.WriteLine("Entering index action");
            return View();
        }

        [HttpPost("Index")]
        public IActionResult Index(WeatherForecastModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Debug.WriteLine("Redirecting to success action");
            model.Date = DateTime.Now;
            ForecastList.Add(model);
            return RedirectToAction(nameof(Success));
        }

        [Route("Success")]
        public IActionResult Success()
        {
            Debug.WriteLine("Entering Success action");
            return View();
        }

        [Route("Browse")]
        public IActionResult Browse()
        {
            return View();
        }

    }
}
