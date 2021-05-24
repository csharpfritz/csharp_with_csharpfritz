using System;
using Xunit;

namespace MyApp.Test.GivenCalculator
{

	public class WhenAdding : BaseFixture
	{


		[Theory]
		[InlineData(2,3, 5)]
		[InlineData(6,-1, 5)]
		[InlineData(7,9, 16)]
		[InlineData(-3,-2, -5)]
		public void ThenTheOutputShouldBeAddedProperly(decimal arg1, decimal arg2, decimal result) {

			// arrange
			// var arg1 = 2;
			// var arg2 = 3;

			// act
			var output = _sut.Sum(arg1, arg2);

			// assert
			Assert.Equal(result, output);

		}

		[Fact]
		public void ThenShouldCallNext() {

			// arrange
			bool nextOpCalled = false;
			decimal NextOp(decimal arg1, decimal arg2) {
				nextOpCalled = true;
				return 0m;
			}

			// act
			_sut.Sum(1, 2, NextOp);

			// assert
			Assert.True(nextOpCalled);

		}

	}

}