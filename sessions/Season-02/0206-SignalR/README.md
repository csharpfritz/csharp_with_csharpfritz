# Session 0206 - Build for the Live Web with ASP.NET Core SignalR

Emote demo:  https://fritzsignalr.azurewebsites.net/Emote

What is SignalR:  https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/introduction-to-signalr

Ovserview:  https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-5.0

JavaScript client
npm install @microsoft/signalr


Add WithAutomaticReconnect([1000,2000,3000])


	#error {
		border: 1px solid red;
		padding: 10px;
		margin: 10px;
		color: red;
		font-weight: bold;
		display: none;
	}

<div id="error"></div>


		connection.onreconnecting(e => {
			console.log("Reconnecting...");
			document.getElementById("error").innerText = "Connection lost... Attempting to reconnect";
			document.getElementById("error").style.display = "block"; 
		});

		connection.onreconnected(e => {
			document.getElementById("error").innerText = "";
			document.getElementById("error").style.display = "none";
		});

		connection.onclose(e => {
			document.getElementById("error").innerText = "Connection lost... Refresh to attempt reconnection";
			document.getElementById("error").style.display("block");
		});


Scaleout:  Azure SignalR Service or Redis Backplane