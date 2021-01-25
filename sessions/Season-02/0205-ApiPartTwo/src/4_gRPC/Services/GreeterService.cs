using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace _4_gRPC
{
  public class GreeterService : Greeter.GreeterBase
  {
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
      _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
      return Task.FromResult(new HelloReply
      {
        Message = "Hello " + request.Name
      });
    }

    public override async Task CountStream(Empty request, IServerStreamWriter<CountData> responseStream, ServerCallContext context)
    {

        for (var i=0; i<10; i++) {

            if (context.CancellationToken.IsCancellationRequested) break;

            await Task.Delay(500);

            await responseStream.WriteAsync(new CountData {
                Count=i,
                Timestamp = Timestamp.FromDateTime(DateTime.Now)
            });

        }

    }



  }
}
