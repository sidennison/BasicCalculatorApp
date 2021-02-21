using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCalculator
{
    public interface IOperationStrategy
    {
        double Calculate(double value1, double value2);
    }
}
