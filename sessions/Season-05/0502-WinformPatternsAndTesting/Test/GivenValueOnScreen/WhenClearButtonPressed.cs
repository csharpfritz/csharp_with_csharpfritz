using MyApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.GivenValueOnScreen
{
	public class WhenClearButtonPressed
	{

		[Fact]
		public void ThenTheScreenShowsZero()
		{

			// arrange
			var view = new StubView();
			var sut = new Presenter(view);

			// act
			sut.NumberButtonPressed("2");
			sut.ClearButtonPressed();

			// assert
			Assert.Equal("0.", view.ScreenDisplay);

		}



	}
}
