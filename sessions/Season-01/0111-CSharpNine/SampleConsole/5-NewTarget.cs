using System;
using System.Drawing;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace SampleConsole {

	public class NewTarget {

		public static void Demo() {

			var t = new NewTarget();
			// t.Demo1();
			t.Demo2();

		}

		public void Demo1() {

			List<int> myList = new();      

			// Repeated object initializers
			Point[] numbers = {new (1,1), new (1,2), new (1,3)};
			WriteLine(numbers.Length);

		}

		public void Demo2() {

			WriteLine("List count: " + CountElementsInList(new() {1,2,3,4,5,6}));

			int CountElementsInList(List<int> myList) {
				return myList.Count();
			}

		}

	}
}