using Xunit;

namespace MyTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var outputFromSomethingCool = 2;
            Assert.Equal(2, outputFromSomethingCool);
        }


        [Fact]
        public void Test2()
        {

            Assert.True(true);
        }

        [Fact]
        public void Test3()
        {

            Assert.Equal("Jeff", "Jeff");
        }

    }
}