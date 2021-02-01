using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Session0206.Hubs
{

	public class ShapeHub : Hub
	{

		public async Task ServerMoveShape(int x, int y)
		{

			await Clients.Others.SendAsync("ClientMoveShape", x, y);

		}

		private static int _Count;

    public override async Task OnConnectedAsync()
    {
			_Count++;
			await Clients.All.SendAsync("Count", _Count);
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
			_Count--;
			await Clients.All.SendAsync("Count", _Count);
    }

  

	}

}