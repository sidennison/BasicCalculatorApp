using BasicCalculator;
using System;
using Xunit;

namespace BasicCalculator.Test
{
    public class BasicCalculatorSubtractTests
    {
        // Prepare strategies
        readonly Subtract subtract = new Subtract();

        [Theory]
        [InlineData(1.0D, 2, 1)]
        [InlineData(-2.0D, -4, -2)]
        [InlineData(-5.0D, -4, 1)]
        [InlineData(0.0D, int.MaxValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue, 0)]
        [InlineData(888888888D, 999999999, 111111111)]
        public void TestSubtractInts(double expected, int value1, int value2)
        {
            Assert.Equal(expected, Calculator.Calculate(subtract, value1, value2));
        }

        [Theory]
        [InlineData(1.0D, 2.0D, 1.0D)]
        [InlineData(0.0D, -1.0D, -1.0D)]
        [InlineData(0.0D, 0.0D, 0.0D)]
        [InlineData(-2.0D, -0.0D, 2.0D)]
        [InlineData(0.75D, 1.5D, 0.75D)]
        [InlineData(25.0D, 24.75D, -0.25D)]
        [InlineData(double.MaxValue, double.MaxValue, 0.0D)]
        [InlineData(double.MinValue, double.MinValue, 0.0D)]
        public void TestSubtractDoubles(double expected, double value1, double value2)
        {
            Assert.Equal(expected, Calculator.Calculate(subtract, value1, value2));
        }

        [Fact]
        public void TestSubtractDoubleFromInt()
        {
            Assert.Equal(1.5D, Calculator.Calculate(subtract, 3, 1.5D));
        }

        [Fact]
        public void TestSubtractIntFromDouble()
        {
            Assert.Equal(-1.0D, Calculator.Calculate(subtract, 1.0D, 2));
        }
    }
}
