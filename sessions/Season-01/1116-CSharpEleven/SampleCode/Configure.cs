using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEleven
{

	public class Configure
	{
		public void DoConfigure()
		{
			Console.WriteLine("Public configure");
		}
	}

	public class DoPublicTests
	{

		public void DoTest()
		{

			var configure = new Configure();
			configure.DoConfigure();

		}

	}

}

}
