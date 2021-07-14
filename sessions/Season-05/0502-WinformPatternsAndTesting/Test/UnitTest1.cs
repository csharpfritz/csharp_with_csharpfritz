using System;
using Xunit;
using MyApp.Core;

namespace Test
{
	public class UnitTest1
	{
		[Fact]
		public void MultiplyThreeAndThree()
		{

			// arrange
			var view = new StubView();
			var sut = new Presenter(view);

			// act
			sut.NumberButtonPressed("3");
			sut.OperatorButtonClick("x");
			sut.NumberButtonPressed("3");
			sut.OperatorButtonClick("+ / =");

			// assert
			Assert.Equal("9", view.ScreenDisplay);

		}

		[Fact]
		public void SumTwoAndTwo()
		{

			// arrange
			var view = new StubView();
			var sut = new Presenter(view);

			// act
			sut.NumberButtonPressed("2");
			sut.OperatorButtonClick("+ / =");
			sut.NumberButtonPressed("2");
			sut.OperatorButtonClick("+ / =");

			// assert
			Assert.Equal("4", view.ScreenDisplay);

		}

		[Fact]
		public void AddThreeNumbers()
		{

			// arrange
			var view = new StubView();
			var sut = new Presenter(view);

			// act
			sut.NumberButtonPressed("2");
			sut.OperatorButtonClick("+ / =");
			sut.NumberButtonPressed("3");
			sut.OperatorButtonClick("+ / =");
			sut.NumberButtonPressed("4");
			sut.OperatorButtonClick("+ / =");

			// assert
			Assert.Equal("9", view.ScreenDisplay);

		}

	}


	public class StubView : ICalculatorView
	{
		public string ScreenDisplay { get; set; }
	}

}
