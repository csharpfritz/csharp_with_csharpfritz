using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Microsoft.DotNet.Interactive;
using Microsoft.DotNet.Interactive.Events;

namespace NotebookUnit
{
  public class RunTestsMagicCommand : IKernelExtension
  {
    public async Task OnLoadAsync(Kernel kernel)
    {

      var testCommand = new Command("#!test", "Run the tests in this notebook")
      {
        new Option<string>("-s", "Dunno why I'm adding this, I just want it to run")
      };

      testCommand.Handler = CommandHandler.Create(async (KernelInvocationContext context) =>
      {
        context.Publish(
        new DisplayedValueProduced
          ("This is a test",
          context.Command,
          new[] { new FormattedValue("text/plain", "This is my formatted value") }
          )
        );
      });

      kernel.AddDirective(testCommand);

      // This doesn't appear to be working
      //if (KernelInvocationContext.Current is { } context)
      //{
      //    await context.DisplayAsync($"`{nameof(RunTestsMagicCommand)}` is loaded. It adds unit test capabilities");
      //}

    }
  }
}
