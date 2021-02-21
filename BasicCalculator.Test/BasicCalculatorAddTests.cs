using BasicCalculator;
using System;
using Xunit;

namespace BasicCalculator.Test
{
    public class BasicCalculatorAddTests
    {
        // Prepare strategy
        readonly Add add = new Add();

        [Theory]
        [InlineData(3.0D, 2, 1)]
        [InlineData(-6.0D, -4, -2)]
        [InlineData(-3.0D, -4, 1)]
        [InlineData(-1.0D, int.MaxValue, int.MinValue)]
        [InlineData(int.MaxValue, int.MaxValue, 0)]
        [InlineData(int.MinValue, int.MinValue, 0)]
        [InlineData(999999999D, 111111111, 888888888)]
        public void TestAddInts(double expected, int value1, int value2)
        {
            Assert.Equal(expected, Calculator.Calculate(add, value1, value2));
        }

        [Theory]
        [InlineData(2.0D, 1.0D, 1.0D)]
        [InlineData(-2.0D, -1.0D, -1.0D)]
        [InlineData(0.0D, 0.0D, 0.0D)]
        [InlineData(2.0D, -0.0D, 2.0D)]
        [InlineData(1.0D, 1.0D, 0.0D)]
        [InlineData(1.0D, 0.0D, 1.0D)]
        [InlineData(1.5D, 0.75D, 0.75D)]
        [InlineData(24.75D, -0.25D, 25.0D)]
        [InlineData(double.MaxValue, double.MaxValue, 0.0D)]
        [InlineData(double.MinValue, double.MinValue, 0.0D)]
        public void TestAddDoubles(double expected, double value1, double value2)
        {
            Assert.Equal(expected, Calculator.Calculate(add, value1, value2));
        }

        [Theory]
        [InlineData(3.0D, 2, 1.0D)]
        [InlineData(-1.0D, -2, 1.0D)]
        [InlineData(1.0D, 2, -1.0D)]
        public void TestAddIntToDouble(double expected, int value1, double value2)
        {
            Assert.Equal(expected, Calculator.Calculate(add, value1, value2));
        }

        [Fact]
        public void TestAddDoubleToInt()
        {
            Assert.Equal(3.0D, Calculator.Calculate(add, 1.0D, 2));
        }
    }
}
