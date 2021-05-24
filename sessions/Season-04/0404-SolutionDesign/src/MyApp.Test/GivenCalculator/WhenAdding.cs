using System;
using Xunit;

namespace MyApp.Test.GivenCalculator
{
		
	public class WhenAdding 
	{

		[Fact]
		public void ShouldAddProperly() {

			// arrange
			var arg1 = 2;
			var arg2 = 3;

			// act
			var sut = new Calculator("Fritz");
			var output = sut.Sum(arg1, arg2);

			// assert
			Assert.Equal(arg1 + arg2, output);

		}

	}

}