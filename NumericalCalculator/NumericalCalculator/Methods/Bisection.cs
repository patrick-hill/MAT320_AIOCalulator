using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator.Methods
{
    class Bisection : BaseMethod
    {
        // Rules
        // a & b must have opposite signs
        // c = (a+b)/2
        // f(c) replaces negative f(a) or f(b)
        public void Evaluate(Expression function, double a, double b, double tolerance)
        {
            addToLog("Starting Bisection Method");
            double cNew, functionA, functionB, functionC;
            double c = (a + b) / 2;
            int iteration = 0;

            // Calculate F(a,b,c) until tolerance is reached
            while (true)
            {
                iteration++;


                // Functions
                functionA = evaluate(function, a);
                functionB = evaluate(function, b);
                functionC = evaluate(function, c);

                addToLog(newLine + "Iteration " + iteration);
                addToLog("a= " + RoundToSignificantDigits(a, 4) + tab
                    + "b= " + RoundToSignificantDigits(b, 4) + tab
                    + "c= " + RoundToSignificantDigits(c, 4) + tab
                    + tab
                    + "F(a)= " + RoundToSignificantDigits(functionA, 4) + tab
                    + "F(b): " + RoundToSignificantDigits(functionB, 4) + tab
                    + "F(c): " + RoundToSignificantDigits(functionC, 4));

                /// Rule ///
                // c value replaces either a or b depending on same sign of f(a) or f(b)
                if (functionC < 0 && functionA < 0)
                //if (functionC < functionB)
                    a = c;
                else
                    b = c;

                // calc. new c
                cNew = (a + b) / 2;

                addToLog("c swaps with " + ((functionC < functionB) ? "a" : "b"));

                // check tolerance
                bool withinTolerance = inTolerance(tolerance, c, cNew);
                if (withinTolerance)
                    break;
                
                c = cNew;

                if (iteration >= 350)
                {
                    addToLog("Iteration threshold reached, STOPPING!");
                    break;
                }
            }
            // if here, we've found our root :)
            addToLog("ROOT FOUND: " + c);
        }
    }
}
