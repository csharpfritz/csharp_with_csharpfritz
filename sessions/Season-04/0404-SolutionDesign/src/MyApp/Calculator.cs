using System;

namespace MyApp {

	/// <summary>
	/// A simple Calculator.
	/// </summary>
	public partial class Calculator
    {

		#region Fields

		private string _Name;

		#endregion

		#region Constructors / Finalizers

		public Calculator(string name)
		{
				_Name = name;
		}

		/// <summary>
		/// Finalizes an instance of the <see cref="Calculator"/> class.
		/// </summary>
		/// <value></value>
		~Calculator() {
			this._Name = string.Empty;
		}

		#endregion
		public delegate decimal Operation(decimal argOne, decimal argTwo);

		public event EventHandler<EventArgs> OnSum;

		public enum SupportedOperations {
			Sum,
			Difference,
			Product
		}

		public string Name { get { return _Name;} internal set { _Name = value; }}

		/// <summary>
		/// Add two values together.
		/// </summary>
		/// <param name="argOne">First value to add.</param>
		/// <param name="argTwo">Second value to add.</param>
		/// <param name="nextOp">A next operation to trigger.</param>
		/// <returns>The sum of the two values.</returns>
		public decimal Sum(decimal argOne, decimal argTwo, Operation nextOp = null) {

			var outValue = argOne + argTwo;
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