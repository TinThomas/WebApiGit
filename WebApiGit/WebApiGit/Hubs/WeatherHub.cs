﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebApiGit.Data;
using WebApiGit.Models;


namespace WebApiGit.Hubs
{
    public class WeatherHub : Hub
    {

        public async Task<WeatherForecastModel> UpdateForecasts(WeatherForecastModel item)
        {
            await Clients.All.SendAsync("ReceiveUpdate",
                item.Date,
                item.TemperatureC,
                item.Humidity,
                item.Pressure,
                item.Summary);
            return item;
        }
    }
}
