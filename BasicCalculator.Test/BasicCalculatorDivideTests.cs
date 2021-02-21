using BasicCalculator;
using System;
using Xunit;

namespace BasicCalculator.Test
{
    public class BasicCalculatorDivideTests
    {
        // Prepare strategies
        readonly Divide divide = new Divide();

        [Theory]
        [InlineData(5, 0)]
        public void TestDivideByZeroException(double value1, double value2)
        {
            var ex = Assert.Throws<ArgumentException>(() => Calculator.Calculate(divide, value1, value2));
            Assert.Equal("Cannot divide by zero", ex.Message);
        }

        [Theory]
        [InlineData(5, 10, 2)]
        [InlineData(2.5D, 10, 4)]
        [InlineData(0, 0, 5)]
        [InlineData(-5, -10, 2)]
        [InlineData(-5000, 10000, -2)]
        public void TestDivideInts(double expected, int value1, int value2)
        {
            Assert.Equal(expected, Calculator.Calculate(divide, value1, value2));
        }

        [Theory]
        [InlineData(0.876, 4.38, 5)]
        [InlineData(-0.69, -0.345, 0.5)]
        [InlineData(0.112359549753945, 1.23456789, 10.9876543)]
        public void TestDivideDoubles(double expected, double value1, double value2)
        {
            Assert.Equal(expected, Calculator.Calculate(divide, value1, value2), 10);
        }

        [Fact]
        public void TestDivideDoubleByInt()
        {
            Assert.Equal(0.876, Calculator.Calculate(divide, 4.38, 5));
        }

        [Fact]
        public void TestDivideIntByDouble()
        {
            Assert.Equal(1.14155251141552511415525, Calculator.Calculate(divide, 5, 4.38), 10);
        }
    }
}
