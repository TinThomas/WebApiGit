

var connection = new signalR.HubConnectionBuilder().withUrl("/weatherHub").build();

connection.on("ReceiveUpdate", function(newEntry) {
    var div = document.createElement("div");
    div.textContent = newEntry;
    document.getElementById("forecastList").appendChild(div);
});

connection.start();
