using BasicCalculator;
using System;
using Xunit;

namespace BasicCalculator.Test
{
    public class BasicCalculatorMultiplyTests
    {
        // Prepare strategies
        readonly Multiply multiply = new Multiply();

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(8, 4, 2)]
        [InlineData(-50, 5, -10)]
        [InlineData(350, -35, -10)]
        [InlineData(999999999D, 111111111, 9)]
        public void TestMultiplyInts(double expected, int value1, int value2)
        {
            Assert.Equal(expected, Calculator.Calculate(multiply, value1, value2));
        }

        [Theory]
        [InlineData(3.75D, 2.5D, 1.5D)]
        [InlineData(2.0D, -2.0D, -1.0D)]
        [InlineData(0.0D, 0.0D, 0.0D)]
        [InlineData(0.0D, -0.0D, 2.0D)]
        public void TestMultiplyDoubles(double expected, double value1, double value2)
        {
            Assert.Equal(expected, Calculator.Calculate(multiply, value1, value2));
        }

        [Fact]
        public void TestMultiplyDoubleByInt()
        {
            Assert.Equal(21.9, Calculator.Calculate(multiply, 4.38, 5));
        }

        [Fact]
        public void TestMultiplyIntByDouble()
        {
            Assert.Equal(21.9, Calculator.Calculate(multiply, 5, 4.38));
        }
    }
}
