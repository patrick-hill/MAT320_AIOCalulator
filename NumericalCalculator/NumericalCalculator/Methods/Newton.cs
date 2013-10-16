using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator.Methods
{
    class Newton : BaseMethod
    {
        int iteration = 0;

        public void Evaluate(Expression exp, Expression derExp, double a, double b, double tolerance)
        {
            addToLog("Starting Newton Method");
            double expX, derExpX, result;
            double current = a;
            double previous = 0;

            while (true)
            {
                iteration++;
                // Functions
                expX = evaluate(exp, current);
                derExpX = evaluate(derExp, current);
                result = current - (expX / derExpX);

                // log
                addToLog(newLine + "Iteration: " + iteration);
                addToLog("F(x)= " + RoundDigit(expX, 4) + tab
                    + "F'(x)= " + RoundDigit(derExpX, 4) + tab
                    + "x= " + RoundDigit(result, 4));

                // swaps
                previous = current;
                current = result;

                bool withinTolerance = inTolerance(tolerance, previous, current);
                if (withinTolerance)
                    break;
            }
            addToLog("ROOT FOUND: " + result);
        }
    }
}
