using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using WebApiGit.Data;
using WebApiGit.Hubs;
using WebApiGit.Models;


namespace WebApiGit.Controllers
{
    [Route("[Controller]")]
    public class WeatherForecastController : Controller
    {
        public static WeatherForecastContext Db = new WeatherForecastContext();

        private readonly IHubContext<WeatherHub> _hubContext;

        public WeatherForecastController(IHubContext<WeatherHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("Subscribe")]
        public IActionResult Subscribe()
        {
            return View();
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            Debug.WriteLine("Entering index action");
            return View();
        }

        [HttpPost("Upload")]
        public async System.Threading.Tasks.Task<IActionResult> IndexAsync([FromBody] WeatherForecastModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            Debug.WriteLine("Redirecting to success action");
            model.Date = DateTime.Now;
            Db.Add(model);
            Db.SaveChanges();
            await _hubContext.Clients.All.SendAsync("ReceiveUpdate", model);
            return Ok(model);
        }

        [Route("Browse")]
        public IActionResult Browse()
        {
            string json = "";
            foreach (var forecast in Db.WeatherForecasts)
            {
                json += JsonConvert.SerializeObject(forecast);
            }

            return Ok(json);
        }

        [Route("Reset")]
        public IActionResult Reset()
        {
            foreach (var forecast in Db.WeatherForecasts)
            {
                Db.Remove(forecast);
            }

            WeatherForecastModel newForecast1 =
            new WeatherForecastModel()
            {
                Date = DateTime.Now,
                Name = "Maarslet",
                Lat = 56.060059,
                Lon = 10.158049,
                TemperatureC = 20,
                Pressure = 20,
                Humidity = 20,
                Summary = WeatherForecastModel.SummaryEnum.Warm
            };
            Db.Add(newForecast1);
            WeatherForecastModel newForecast2 =
                new WeatherForecastModel()
                {
                    Date = DateTime.Now,
                    Name = "Katrinebjerg",
                    Lat = 56.172535,
                    Lon = 10.191472,
                    TemperatureC = 21,
                    Pressure = 21,
                    Humidity = 21,
                    Summary = WeatherForecastModel.SummaryEnum.Warm
                };
            Db.Add(newForecast2);
            Db.SaveChanges();
            return Ok();
        }

    }
}
