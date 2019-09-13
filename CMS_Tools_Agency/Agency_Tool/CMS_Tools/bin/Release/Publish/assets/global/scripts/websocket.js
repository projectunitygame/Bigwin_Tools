var ws;
$(document).ready(function () {
    //var userData = $.parseJSON($("#_userdata").val());
    //console.log(userData);
    //if (userData[0].Token != "")
    //    ConnectServer(userData[0].Token);
});
function ConnectServer() {
    console.log("Connect server");
    //var srv = window.location.hostname + (location.port ? ":" + location.port : "") + "/Server/ServerHandler.ashx";//"/echohandler.ashx";//"/WebSocketServer.ashx";
    var srv = window.location.hostname + (location.port ? ":" + location.port : "") + "/ws/ServerHandler.ashx?token=" + token;//"/echohandler.ashx";//"/WebSocketServer.ashx";
    console.log(srv);
    ws = new WebSocket("wss://" + srv);    
    ws.onopen = function (evt) {
        console.log("connected");
        //$("#spanStatus").text("connected");
    };
    ws.onmessage = function (evt) {
        console.log(evt);
        //$("#spanStatus").append(evt.data + "<br>");
    };
    ws.onerror = function (evt) {
        console.log(evt.message);
        //$("#spanStatus").append(evt.message + "<br>");
    };
    ws.onclose = function (evt) {
        console.log(evt.reason);
        if (evt.reason == "DISCONNECT_CLIENT")
            window.location.href = "login.aspx";
    };
}

function Disconnect() {
    ws.close();
}

function SendData() {
    if (ws.readyState == WebSocket.OPEN) {
        ws.send($("#txtData").val());
    }
    else {
        //$("#spanStatus").text("Connection is closed");
    }
}