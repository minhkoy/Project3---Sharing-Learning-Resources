"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/GetUserOnline").build();

connection.start();
//connection.start().then(function () {
    
//    connection.invoke("GetOnlineUsersCounter").catch(function (err) {
//        return console.error(err.toString())
//    })
//}).catch(function (err) {
//    return console.error(err.toString());
//});

connection.on("GetOnlineUsersCounter", function (onlineUsersCounter) {
    let usersOnline = document.getElementById('usersOnline');
    usersOnline.textContent = onlineUsersCounter;
})