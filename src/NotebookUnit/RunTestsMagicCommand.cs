using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Microsoft.DotNet.Interactive;
using Microsoft.DotNet.Interactive.Events;
using Microsoft.DotNet.Interactive.Formatting;

namespace NotebookUnit
{
  public class RunTestsMagicCommand : IKernelExtension
  {
    public async Task OnLoadAsync(Kernel kernel)
    {

      var testCommand = new Command("#!test", "Run the tests in this notebook")
      {
        new Option<Action[]>(new string[] {"-t", "--tests" }, () => new Action[] { }, "Specify tests to run")
      };

      testCommand.Handler =
      CommandHandler.Create(async (Action[] tests, KernelInvocationContext context) =>
        RunTests(tests, context));

      kernel.AddDirective(testCommand);

      if (KernelInvocationContext.Current is { } context)
      {
        await context.DisplayAsync($"`{nameof(RunTestsMagicCommand)}` is loaded. It enables testing in notebooks", "text/markdown");
      }

    }

		private object RunTests(Action[] tests, KernelInvocationContext context)
		{

      if (tests == null || tests.Length == 0) {
        context.Fail(message: "No tests");
        return null;
			}

      context.Publish(new DisplayedValueProduced("Tests to be run", context.Command, new[] {
        new FormattedValue(PlainTextFormatter.MimeType, "Tests will be run")
      }));

      return new object();

		}


	}
}
