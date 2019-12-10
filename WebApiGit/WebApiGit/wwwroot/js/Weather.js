var connection = new signalR.HubConnectionBuilder().withUrl("/weatherHub").build();

connection.on("ReceiveUpdate", function(date, temperature, humidity, pressure, summary) {
    var _date = document.createElement("div");
    var _temperature = document.createElement("div");
    var _humidity = document.createElement("div");
    var _pressure = document.createElement("div");
    var _summary = document.createElement("div");
    _date.textContent = "Date: "+date;
    _temperature.textContent = "Temperature: "+temperature;
    _humidity.textContent = "Humidity: " + humidity;
    _pressure.textContent = "Pressure: "+ pressure;
    _summary.textContent = "Summary: "+summary;
    document.getElementById("forecastList").appendChild(_date);
    document.getElementById("forecastList").appendChild(_temperature);
    document.getElementById("forecastList").appendChild(_humidity);
    document.getElementById("forecastList").appendChild(_pressure);
    document.getElementById("forecastList").appendChild(_summary);
});

connection.start();
