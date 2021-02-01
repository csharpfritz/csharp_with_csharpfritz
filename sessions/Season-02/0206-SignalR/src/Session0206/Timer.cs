using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Session0206.Hubs;

namespace Session0206
{

  public class TimerService : IHostedService
  {
    private readonly IHubContext<ShapeHub> _Context;
    private Task _ExecutionThread;

    public TimerService(IHubContext<ShapeHub> context)
    {
      this._Context = context;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      _ExecutionThread = Execute(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }

    public async Task Execute(CancellationToken token) 
    {

      while (!token.IsCancellationRequested)
      {

        _Context.Clients.All.SendAsync("timer", DateTime.Now.ToString("mm:ss"));
        await Task.Delay(1000);

      }

    } 

  }

}