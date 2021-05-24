namespace MyApp.Test.GivenCalculator
{
	public abstract class BaseFixture {
		protected Calculator _sut;

		public BaseFixture()
		{
			_sut = new Calculator("Fritz");
		}

	}

}