using System;

namespace MyApp {

	public class Calculator {

		private string _Name;

		public Calculator(string name)
		{
				_Name = name;
		}

		~Calculator() {
			_Name = string.Empty;
		}

		public delegate decimal Operation(decimal argOne, decimal argTwo);

		public event EventHandler<EventArgs> OnSum;

		public enum SupportedOperations {
			Sum,
			Difference,
			Product
		}

		public string Name { get { return _Name;} internal set { _Name = value; }}

		public decimal Sum(decimal argOne, decimal argTwo, Operation nextOp = null) {

			var outValue = argOne+argTwo;
			if (nextOp != null) nextOp(argOne, argTwo);

			if (OnSum != null) OnSum(this, new EventArgs());

			return outValue;

		}

		public decimal Difference(decimal argOne, decimal argTwo, Operation nextOp = null) {

			var outValue = argOne - argTwo;
			if (nextOp != null) nextOp(argOne, argTwo);

			return outValue;

		}

		public decimal Product(decimal argOne, decimal argTwo, Operation nextOp = null) {

			var outValue = argOne * argTwo;
			if (nextOp != null) nextOp(argOne, argTwo);

			return outValue;

		}

	}

}