using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator
{
    class Calculator
    {
        Calculator()
        {
            
        }

        void bisect(String function, String range, String tolerance)
        {
            // Rules
            // c = (a+b)/2
            // f(c) replaces negative f(a) or f(b)
            Expression eFunction = new Expression(function);
            
            String[] ranges = range.Split(',');
            int a = int.Parse(ranges[0]);
            int b = int.Parse(ranges[1]);
            int c = (a + b) / 2;

            
        }
    }
}
