using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Session0206.Hubs
{
	
	public class EmoteHub : Hub
	{

		private static int _Count = 0;
		private static long _EmoteClicks = 0;

		public override async Task OnConnectedAsync()
		{

			var group = Context.GetHttpContext().Request.Query["group"].ToString();
			Console.WriteLine($"Connecting group {group}");
			if (!string.IsNullOrEmpty(group)) Groups.AddToGroupAsync(Context.ConnectionId, group);

			Interlocked.Increment(ref _Count);
			await Clients.All.SendAsync("Count", _Count);
			base.OnConnectedAsync();
		}

		public override async Task OnDisconnectedAsync(Exception exception)
		{
			Interlocked.Decrement(ref _Count);
			await Clients.All.SendAsync("Count", _Count);
		}



		public async Task SendEmote(int emoteId) 
		{

			Interlocked.Increment(ref _EmoteClicks);
			await Clients.Group("obs").SendAsync("FlyEmote", emoteId);
			await Clients.All.SendAsync("clicks", _EmoteClicks);
			
		}

		
	}

}