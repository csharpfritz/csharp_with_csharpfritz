using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using VerifyCS = BraceAnalyzer.Test.CSharpCodeFixVerifier<
		BraceAnalyzer.BraceAnalyzerAnalyzer,
		BraceAnalyzer.BraceAnalyzerCodeFixProvider>;

namespace BraceAnalyzer.Test
{
	[TestClass]
	public class BraceAnalyzerUnitTest
	{
		//No diagnostics expected to show up
		[TestMethod]
		public async Task TestMethod1()
		{
			var test = @"";

			await VerifyCS.VerifyAnalyzerAsync(test);
		}

		//Diagnostic and CodeFix both triggered and checked for
		[TestMethod]
		public async Task TestMethod2()
		{
			var test = @"
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

          if (true)
              Console.WriteLine(""This is a test"");

				}
	}
}
";

			var fixtest = @"
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

          if (true) 
					{
              Console.WriteLine(""This is a test"");
					}

				}
	}
}
";

			await VerifyCS.VerifyCodeFixAsync(test, fixtest);
		}
	}
}
