using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Session0206.Hubs
{
	
	public class EmoteHub : Hub
	{

		public override Task OnConnectedAsync()
		{

			var group = Context.GetHttpContext().Request.Query["group"].ToString();
			Console.WriteLine($"Connecting group {group}");
			if (!string.IsNullOrEmpty(group)) Groups.AddToGroupAsync(Context.ConnectionId, group);

			return base.OnConnectedAsync();
		}

		public async Task SendEmote(int emoteId) 
		{

			Console.WriteLine($"Button received: {emoteId}");

			await Clients.Group("obs").SendAsync("FlyEmote", emoteId);
			
		}

		
	}

}