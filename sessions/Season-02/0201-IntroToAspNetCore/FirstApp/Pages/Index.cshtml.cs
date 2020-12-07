using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FirstApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger _logger;
		private readonly Stopwatch _Timer = Stopwatch.StartNew();
		private readonly Stopwatch _Timer2;
		private readonly Stopwatch _Timer3;

		public IndexModel(ILoggerFactory loggerFactory)
		{
			_Timer2 = Stopwatch.StartNew();
			_logger = loggerFactory.CreateLogger("FooMagoo");
			_logger.LogInformation($"Timer is at: {_Timer.ElapsedTicks} ticks");
			_Timer3 = Stopwatch.StartNew();
		}

		public string FontColor { get { return DateTime.Now.Second % 2 == 0 ? "blue" : "red"; }}

		public void OnGet()
		{

			_logger.LogInformation("Output the Index page");
			_logger.LogInformation($"Page rendered in: {_Timer.ElapsedTicks} ticks");
			_logger.LogInformation($"Timer2 in: {_Timer2.ElapsedTicks} ticks");
			_logger.LogInformation($"Timer3 in: {_Timer3.ElapsedTicks} ticks");

		}
	}
}
