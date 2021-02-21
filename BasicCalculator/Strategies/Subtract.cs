using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCalculator
{
    public class Subtract : IOperationStrategy
    {
        public double Calculate(double value1, double value2)
        {
            return value1 - value2;
        }
    }
}
