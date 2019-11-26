using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebApiGit.Controllers
{
    [Route("[Controller]")]
    public class WeatherForecastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }




    }
}
