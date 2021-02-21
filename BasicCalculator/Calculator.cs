using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCalculator
{
    public abstract class Calculator
    {
        // Uses Strategy design pattern
        public static double Calculate(IOperationStrategy operation, double value1, double value2)
        {
            return operation.Calculate(value1, value2);
        }
    }
}
