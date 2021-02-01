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


	}

}