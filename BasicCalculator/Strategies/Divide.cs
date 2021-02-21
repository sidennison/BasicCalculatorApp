using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCalculator
{
    public class Divide : IOperationStrategy
    {
        public double Calculate(double value1, double value2)
        {
            if (value2 == 0)
                throw new ArgumentException("Cannot divide by zero");

            return value1 / value2;
        }
    }
}
