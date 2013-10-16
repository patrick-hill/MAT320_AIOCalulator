using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator.Methods
{
    class RegulaFalsi : BaseMethod
    {
        /// Rules
        // a < b
        int iteration = 0;
        public void Evaluate(Expression exp, double a, double b, double tolerance)
        {
            addToLog("Starting Regula Falsi Method");
            double functionA, functionB, functionX, x, xNew;

            while (true)
            {
                iteration++;
                // Functions
                functionA = evaluate(exp, a);
                functionB = evaluate(exp, b);
                x = ((a * functionB) - (b * functionA)) / (functionB - functionA);
                functionX = evaluate(exp, x);

                // log
                addToLog(newLine + "Iteration: " + iteration);
                addToLog("a= " + RoundDigit(a, 4) + tab
                    + "b= " + RoundDigit(b, 4) + tab
                    + "x=" + RoundDigit(x, 4) + tab
                    + tab
                    + "F(a)= " + RoundDigit(functionA, 4) + tab
                    + "F(b): " + RoundDigit(functionB, 4) + tab
                    + "F(x): " + RoundDigit(functionX, 4) + tab);

                // swapping: doesnt matter, no rule, try a 50 times, then b 
                if (iteration > 50)
                {
                    b = x;
                    functionB = functionX;
                }
                else
                {
                    a = x;
                    functionA = functionX;
                }
                addToLog("x swaps with " + ((iteration > 50) ? "b" : "a"));

                xNew = ((a * functionB) - (b * functionA)) / (functionB - functionA);

                // check tolerance
                bool withinTolerance = inTolerance(tolerance, x, xNew);
                if (withinTolerance)
                    break;

                x = xNew;

                if (iteration >= 350)
                {
                    addToLog("Iteration threshold reached, STOPPING!");
                    break;
                }
            }
            addToLog("ROOT FOUND: " + x);
        }
    }
}
