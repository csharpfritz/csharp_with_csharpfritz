using System;
using static System.Console;

namespace SampleConsole {

	public class Init {

		public static void Demo() {

			Demo1();

		}

#region Demo1		

		public static void Demo1() {

			var l = new LogEntry {
				Severity = LogSeverity.Error,
				LogTimestampUtc = DateTime.UtcNow,
				Description = "Bad dates..."
			};

			WriteLine(l);

		}

		public struct LogEntry {

			public readonly LogSeverity Severity;

			public readonly DateTime LogTimestampUtc;

			public readonly string Description;

			public override string ToString()
			{
				return $"{LogTimestampUtc} - {Severity} - {Description}";
			}

		}

		public enum LogSeverity {
			Error,
			Warning,
			Debug,
			Info
		}

#endregion

	}

}