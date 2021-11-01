using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyTests.GivenMyCalculator
{
    public class WhenAddingTwoNumbers
    {

        [Fact]
        public void ThenTheyShouldAddProperly()
        {

            // Arrange
            var calc = new MyLibrary.Calculator();
            var add1 = 2;
            var add2 = 3;

            // Act
            var result = calc.Sum(add1, add2);

            // Assert
            Assert.Equal(5, result);


        }

    }
}
