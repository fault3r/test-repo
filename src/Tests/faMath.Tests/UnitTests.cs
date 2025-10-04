using System;
using System.IO.Compression;

namespace faMath.Tests
{
    public class FaMathUnitTests
    {
        [Fact]
        public void Sum_LogicTest()
        {
            var math = new FaMath();
            int x = 20;
            int y = 6;

            int result = math.Sum(x, y);

            Assert.Equal(26, result);
        }

        [Theory]
        [InlineData(20, 6, 26)]
        [InlineData(32, -6, 26)]
        [InlineData(0, 0, 0)]
        public void Sum_ComplexLogicTest(int x, int y, int expected)
        {
            var math = new FaMath();

            Assert.Equal(expected, math.Sum(x, y));
        }

        [Fact]
        public void Div_ByZeroException()
        {
            var math = new FaMath();
            int x = 20;
            int y = 0;

            Assert.Throws<DivideByZeroException>(() => math.Div(x, y));
        }

     
    }
}