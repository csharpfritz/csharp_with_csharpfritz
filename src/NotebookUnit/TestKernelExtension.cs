using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Microsoft.DotNet.Interactive;

namespace NotebookUnit
{
  public class TestKernelExtension : IKernelExtension
  {
    public async Task OnLoadAsync(Kernel kernel)
    {

      var testCommand = new Command("#!test", "Run the tests in this notebook");

      testCommand.Handler = CommandHandler.Create(async (KernelInvocationContext context) =>
      {
          await context.DisplayAsync("This is a test", "text/plain");
      });

      kernel.AddDirective(testCommand);

      if (KernelInvocationContext.Current is { } context)
      {
          await context.DisplayAsync($"`{nameof(TestKernelExtension)}` is loaded. It adds unit test capabilities");
      }

    }
  }
}
