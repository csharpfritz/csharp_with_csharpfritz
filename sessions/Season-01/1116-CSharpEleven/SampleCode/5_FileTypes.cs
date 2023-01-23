using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEleven
{

	file class Configure
	{

		public void DoConfigure()
		{
			Console.WriteLine("File scoped configure");
		}

	}

	public class MyTests
	{

		public void DoTest()
		{
			var configure = new Configure();
			configure.DoConfigure();
		}

	}

}
